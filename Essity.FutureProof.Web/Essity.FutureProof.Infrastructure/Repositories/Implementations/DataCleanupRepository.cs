using Essity.FutureProof.Infrastructure.Entities;
using Essity.FutureProof.Infrastructure.Enums;
using Essity.FutureProof.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Essity.FutureProof.Infrastructure.Repositories.Implementations
{
    public class DataCleanupRepository : BaseRepository, IDataCleanupRepository
    {
        private readonly IDbContextFactory<DataContext> _dataContextFactory;

        public DataCleanupRepository(IDbContextFactory<DataContext> dataContextFactory)
        {
            _dataContextFactory = dataContextFactory;
        }

        public async Task<IEnumerable<int>> GetSiteIdsForContactsCleanupAsync(DateTimeOffset offset)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                var siteIds = await dataContext.UbContacts.Where(x => x.DateCreated < offset)
                .Include(x => x.UbConsumer)
                .GroupBy(x => x.UbConsumer.SiteId)
                .Select(x => x.Key ?? 0)
                .ToListAsync()
                .ConfigureAwait(false);

                return siteIds.Where(x => x != 0);
            }
        }

        public async Task<IEnumerable<int>> GetSiteIdsForConsumersCleanupAsync(DateTimeOffset offset, string source)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                var siteIds = await dataContext.UbConsumerConsents.Where(x =>
                    x.DateCreated < offset && x.UbConsent.Source != null && x.UbConsent.Source.Equals(source) &&
                    (x.OptInConfirmed.Equals(false) || x.OptInConfirmed && x.IsUnsubscribed))
                .Include(x => x.UbConsent)
                .GroupBy(x => x.SiteId)
                .Select(x => x.Key ?? 0)
                .ToListAsync()
                .ConfigureAwait(false);

                return siteIds.Where(x => x != 0);
            }
        }

        public async Task<(IEnumerable<UbConsumer> consumersToDelete, int totalDoubleOptins)> GetConsumersForCleanupAsync(int siteId, string source, DateTimeOffset offset, int limit)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                var query = dataContext.UbConsumerConsents.Where(x =>
                    x.SiteId == siteId && x.DateCreated < offset && x.UbConsent.Source != null && x.UbConsent.Source.Equals(source))
                .Include(x => x.UbConsent);

                if (limit > 0)
                {
                    query = (IIncludableQueryable<UbConsumerConsent, UbConsent>)query.Take(limit);
                }

                var commandTimeout = dataContext.Database.GetCommandTimeout();
                dataContext.Database.SetCommandTimeout(60);

                var consumerConsents = await query.OrderBy(x => x.DateCreated).ToListAsync().ConfigureAwait(false);
                var singleOptinConsumerIds = consumerConsents
                    .Where(c => c.OptInConfirmed.Equals(false) || c.OptInConfirmed && c.IsUnsubscribed)
                    .Select(c => c.ConsumerId)
                    .ToList();

                var singleOptinConsumers = await dataContext.UbConsumers
                    .Where(x => singleOptinConsumerIds.Contains(x.Id))
                    .ToListAsync()
                    .ConfigureAwait(false);

                dataContext.Database.SetCommandTimeout(commandTimeout);
                var totalDoubleOptins = consumerConsents.Where(x => x.OptInConfirmed && x.IsUnsubscribed.Equals(false)).Count();
                return (singleOptinConsumers, totalDoubleOptins);
            }
        }

        public async Task<(IEnumerable<UbContact> contacts, IEnumerable<int> singleOptinConsumerIds)> GetContactsForCleanupAsync(int siteId, DateTimeOffset offset, int limit)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                var query = dataContext.UbContacts.Where(x => x.DateCreated < offset && x.UbConsumer.SiteId == siteId);

                if (limit > 0)
                {
                    query = query.Take(limit);
                }

                var contacts = await query.ToListAsync().ConfigureAwait(false);

                foreach (var contact in contacts)
                {
                    if (contact.UbConsumer != null)
                    {
                        contact.UbConsumer.UbConsumerConsents = await dataContext
                            .Entry(contact.UbConsumer)
                            .Collection(c => c.UbConsumerConsents)
                            .Query()
                            .Where(cc => cc.ConsumerId == contact.UbConsumer.Id)
                            .Include(cc => cc.UbConsent)
                            .ToListAsync()
                            .ConfigureAwait(false);
                    }
                }

                var consumerIds = contacts.Select(c => c.ConsumerId).ToList();

                var singleOptinConsumerIds = await dataContext.UbConsumers
                    .Where(x => consumerIds.Contains(x.Id) &&
                                (x.UbConsumerConsents.All(c => c.OptInConfirmed.Equals(false)) ||
                                 x.UbConsumerConsents.Any(c => c.OptInConfirmed && c.IsUnsubscribed)))
                    .Include(x => x.UbConsumerConsents)
                    .Select(x => x.Id)
                    .ToArrayAsync()
                    .ConfigureAwait(false);

                return (contacts, singleOptinConsumerIds);
            }
        }

        public async Task<UbDataCleanupLog> CleanupContactsAsync(int siteId, IEnumerable<int> contactIds, IEnumerable<int> consumerIds, string extraInfo, bool saveChanges)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                var log = new UbDataCleanupLog
                {
                    SiteId = siteId,
                    StartedAt = DateTime.Now,
                    Type = DataCleanupType.Contact,
                    ExtraInfo = extraInfo
                };

                using (var dbContextTransaction = dataContext.Database.BeginTransaction())
                {
                    dataContext.UbDataCleanupLogs.Add(log);

                    await RemoveContactsAsync(contactIds).ConfigureAwait(false);
                    log.NrOfDeletedConsumers = await RemoveConsumersWithConsentsAsync(consumerIds).ConfigureAwait(false);

                    var commandTimeout = dataContext.Database.GetCommandTimeout();
                    dataContext.Database.SetCommandTimeout(90);

                    if (saveChanges)
                    {
                        await dataContext.SaveChangesAsync().ConfigureAwait(false);
                    }

                    dataContext.Database.SetCommandTimeout(commandTimeout);
                    dbContextTransaction.Commit();
                }

                return log;
            }
        }

        public async Task<bool> VerifyCleanupContactsResultAsync(int[] contactIdsExpectedToBeDeleted, int[] consumerIdsExpectedToBeDeleted)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                if (contactIdsExpectedToBeDeleted.Length > 0 && await dataContext.UbContacts.AnyAsync(x => contactIdsExpectedToBeDeleted.Contains(x.Id)).ConfigureAwait(false))
                {
                    var contactsRetained = await dataContext.UbContacts
                        .Where(x => contactIdsExpectedToBeDeleted.Contains(x.Id)).Select(x => x.Id)
                        .ToArrayAsync()
                        .ConfigureAwait(false);

                    throw new DataCleanupException(
                        $"Expected following UbContacts to be deleted: {string.Join(",", contactsRetained)}");
                }

                if (consumerIdsExpectedToBeDeleted.Length > 0 && await dataContext.UbConsumers.AnyAsync(x => consumerIdsExpectedToBeDeleted.Contains(x.Id)))
                {
                    var consumersRetained = await dataContext.UbConsumers
                        .Where(x => consumerIdsExpectedToBeDeleted.Contains(x.Id))
                        .Select(x => x.Id)
                        .ToArrayAsync()
                        .ConfigureAwait(false);

                    throw new DataCleanupException(
                        $"Expected following UbConsumers to be deleted: {string.Join(",", consumersRetained)}");
                }

                return true;
            }
        }

        public async Task<int> RemoveConsumersWithConsentsAsync(IEnumerable<int> consumerIds, bool saveChanges = false)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                var consumersToDelete =
                await dataContext.UbConsumers
                    .Where(x => consumerIds.Contains(x.Id))
                    .Include(x => x.UbConsumerConsents)
                    .ToListAsync()
                    .ConfigureAwait(false);

                var consentsToDelete = consumersToDelete.SelectMany(x => x.UbConsumerConsents).ToList();

                dataContext.UbConsumerConsents.RemoveRange(consentsToDelete);
                dataContext.UbConsumers.RemoveRange(consumersToDelete);

                if (saveChanges)
                {
                    await dataContext.SaveChangesAsync().ConfigureAwait(false);
                }

                return consumersToDelete.Count;
            }
        }

        public async Task<(int nrOfDeletedSubmissions, int nrOfDeletedConsumers)> BatchCleanupSubmissionsAsync(IEnumerable<int> submissionIds, bool saveChanges)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                var submissions = await dataContext.UbContestSubmissions
                .Where(x => submissionIds.Contains(x.Id))
                .ToArrayAsync()
                .ConfigureAwait(false);

                if (submissions.Length <= 0)
                {
                    return (0, 0);
                }

                var consumerIds = submissions.Select(s => s.ConsumerId).ToList();
                var consumersToDelete = await dataContext.UbConsumers
                    .Include(x => x.UbConsumerConsents)
                    .Where(x => consumerIds.Contains(x.Id) &&
                                (x.UbConsumerConsents.All(c => c.OptInConfirmed.Equals(false)) ||
                                 x.UbConsumerConsents.Any(c => c.OptInConfirmed && c.IsUnsubscribed)))
                    .Select(x => x.Id)
                    .ToArrayAsync()
                    .ConfigureAwait(false);

                using (var dbContextTransaction = dataContext.Database.BeginTransaction())
                {
                    dataContext.UbContestSubmissions.RemoveRange(submissions);
                    await RemoveConsumersWithConsentsAsync(consumersToDelete).ConfigureAwait(false);

                    if (saveChanges)
                    {
                        await dataContext.SaveChangesAsync().ConfigureAwait(false);
                    }

                    dbContextTransaction.Commit();
                }

                return (submissions.Length, consumersToDelete.Length);
            }
        }

        public async Task<bool> VerifyCleanupPromotionsResultAsync(int campaignId)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                if (await dataContext.UbContestSubmissions.AnyAsync(x => x.CampaignId.Equals(campaignId)).ConfigureAwait(false))
                {
                    var submissionRetained = await dataContext.UbContestSubmissions
                        .Where(x => x.CampaignId.Equals(campaignId))
                        .Select(x => x.Id)
                        .ToArrayAsync()
                        .ConfigureAwait(false);

                    throw new DataCleanupException(
                        $"Expected following UbContestSubmissions to be deleted: {string.Join(",", submissionRetained)}");
                }

                if (await dataContext.UbContestCodes.AnyAsync(x => x.CampaignId.Equals(campaignId)).ConfigureAwait(false))
                {
                    var codesRetained = await dataContext.UbContestCodes
                        .Where(x => x.CampaignId.Equals(campaignId))
                        .Select(x => x.Id)
                        .ToArrayAsync()
                        .ConfigureAwait(false);

                    throw new DataCleanupException(
                        $"Expected following UbContestCodes to be deleted: {string.Join(",", codesRetained)}");
                }

                return true;
            }
        }

        public async Task<IEnumerable<string?>> GetContactFormExtraInfoFieldsAsync()
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                return await dataContext.UbContacts
                .Where(x => !string.IsNullOrEmpty(x.ExtraInfo))
                .Select(x => x.ExtraInfo)
                .ToListAsync()
                .ConfigureAwait(false);
            }
        }

        public async Task<IEnumerable<string?>> GetContestSubmissionExtraInfoFieldsAsync()
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                return await dataContext.UbContestSubmissions
                .Where(x => !string.IsNullOrEmpty(x.Extra))
                .Select(x => x.Extra)
                .ToListAsync()
                .ConfigureAwait(false);
            }
        }

        private async Task RemoveContactsAsync(IEnumerable<int> contactIds)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                var contacts = await dataContext.UbContacts
                .Where(x => contactIds.Contains(x.Id))
                .ToListAsync()
                .ConfigureAwait(false);

                if (contacts.Any())
                {
                    dataContext.UbContacts.RemoveRange(contacts);
                }
            }
        }
    }
}