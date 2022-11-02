using Essity.FutureProof.Infrastructure.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Essity.FutureProof.Infrastructure.Repositories.Implementations
{
    public class UbConsentsRepository : BaseRepository, IUbConsentsRepository
    {
        private readonly IDbContextFactory<DataContext> _dataContextFactory;

        public UbConsentsRepository(IDbContextFactory<DataContext> dataContextFactory)
        {
            _dataContextFactory = dataContextFactory;
        }

        public List<UbConsent> GetConsentsForSite(int siteId)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                return dataContext.UbConsents.ToList();
            }
        }

        public UbConsent? GetConsent(string source, string typeCode)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                return dataContext.UbConsents.FirstOrDefault(x => (x.Source ?? "")
                .Equals(source, StringComparison.InvariantCultureIgnoreCase)
                && (x.UbConsentType.Code ?? "").Equals(typeCode, StringComparison.InvariantCultureIgnoreCase));
            }
        }

        public List<UbConsent> GetConsentsForSource(string source)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                return dataContext.UbConsents.Include(x => x.UbConsentType).Where(x => (x.Source ?? "").Equals(source, StringComparison.InvariantCultureIgnoreCase)).ToList();
            }
        }

        public List<UbConsent> GetConsentsForSource(string source, int siteId)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                return dataContext.UbConsents.Where(x => (x.Source ?? "").Equals(source, StringComparison.InvariantCultureIgnoreCase)).ToList();
            }
        }

        public async Task SaveConsentsForConsumerAsync(IEnumerable<int> consentIds, UbConsumer consumer, string? version = null, int? contentTypeId = null, int? contentNodeId = null)
        {
            if (!consentIds.Any())
            {
                return;
            }

            foreach (int consentId in consentIds)
            {
                await SaveConsentForConsumerAsync(consentId, consumer, version, contentTypeId, contentNodeId).ConfigureAwait(false);
            }
        }

        public async Task SaveConsentForConsumerAsync(int consentId, UbConsumer consumer, string? version = null, int? contentTypeId = null, int? contentNodeId = null)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                if (SkipSaveData)
                {
                    return;
                }

                int? propertyDataId = await dataContext.GetCmsPropertyDataIdAsync(contentTypeId, contentNodeId).ConfigureAwait(false);

                dataContext.UbConsumerConsents.Add(new UbConsumerConsent
                {
                    ConsentId = consentId,
                    DateCreated = DateTime.Now,
                    ConsumerId = consumer.Id,
                    SiteId = consumer.SiteId,
                    ConsentVersion = version,
                    CMSPropertyDataId = propertyDataId
                });

                await dataContext.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        public UbConsent? GetConsentById(int consentId)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                return dataContext.UbConsents.FirstOrDefault(x => x.Id == consentId);
            }
        }

        public IEnumerable<UbConsent> GetConsentByIds(int[] consentIds)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                return dataContext.UbConsents.Where(x => consentIds.Contains(x.Id));
            }
        }

        public void UpdateDoubleOptIn(int consumerId, int consentId, bool value)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                if (SkipSaveData)
                {
                    return;
                }

                var consent = dataContext.UbConsumerConsents.FirstOrDefault(x => x.ConsumerId == consumerId && x.ConsentId == consentId);

                if (consent == null)
                {
                    throw new Exception(string.Format("UpdateDoubleOptIn failed for consumerId={0}, consentId={1}", consumerId.ToString(), consentId.ToString()));
                }

                consent.OptInConfirmed = value;
                dataContext.SaveChanges();
            }
        }

        public void UnsubscribeConsent(int consumerId, int consentId)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                var consent = dataContext.UbConsumerConsents.FirstOrDefault(x => x.ConsumerId == consumerId && x.ConsentId == consentId);

                if (consent != null)
                {
                    consent.IsUnsubscribed = true;
                    dataContext.SaveChanges();
                }
            }
        }

        public bool ConsentExists(int consentId, int consumerId, int siteId)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                return dataContext.UbConsumerConsents.Any(x => x.ConsumerId == consumerId && x.ConsentId == consentId && x.SiteId == siteId);
            }
        }

        public UbConsumerConsent? GetConsumerConsent(int consentId, int consumerId, int siteId)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                if (SkipSaveData)
                {
                    return new UbConsumerConsent { OptInConfirmed = false };
                }

                return dataContext.UbConsumerConsents.SingleOrDefault(x => x.ConsumerId == consumerId && x.ConsentId == consentId && x.SiteId == siteId);
            }
        }

        public int GetNumberOfConsumerConsentByType(int consentId)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                return dataContext.UbConsumerConsents.Where(x => x.ConsentId == consentId).Count();
            }
        }

        public int GetNumberOfConsumerConsentByType(int consentId, int siteId)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                return dataContext.UbConsumerConsents.Where(x => x.ConsentId == consentId && x.SiteId == siteId).Count();
            }
        }

        public async Task<(int singleOptins, int doubleOptins)> GetContestNewsletterOptinsForCampaignAsync(int campaignId)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                var commandTimeout = dataContext.Database.GetCommandTimeout();
                dataContext.Database.SetCommandTimeout(120);

                var query = @"SELECT c.*
FROM [dbo].[UbContestSubmissions] s
INNER JOIN [dbo].[UbConsumerConsents] c on c.[ConsumerId] = s.[ConsumerId]
WHERE s.[CampaignId] = @campaignId AND c.[ConsentId] = (SELECT Id FROM [dbo].[UbConsents] WHERE [TypeId] = (SELECT Id FROM [dbo].[UbConsentTypes] WHERE Code = 'OPTIN') AND [Source] = 'CONTEST');";

                var consents = await dataContext.UbConsumerConsents.FromSqlRaw(query, new SqlParameter("@campaignId", campaignId)).ToArrayAsync().ConfigureAwait(false);
                dataContext.Database.SetCommandTimeout(commandTimeout);
                return (consents.Count(x => x.OptInConfirmed == false), consents.Count(x => x.OptInConfirmed));
            }
        }
    }
}