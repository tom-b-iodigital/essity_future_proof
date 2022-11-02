using Essity.FutureProof.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Essity.FutureProof.Infrastructure.Repositories.Implementations
{
    public class UbConsumersRepository : BaseRepository, IUbConsumersRepository
    {
        private readonly IDbContextFactory<DataContext> _dataContextFactory;

        public UbConsumersRepository(IDbContextFactory<DataContext> dataContextFactory)
        {
            _dataContextFactory = dataContextFactory;
        }

        public UbConsumer? GetById(int consumerId)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                return dataContext.UbConsumers.FirstOrDefault(x => x.Id == consumerId);
            }
        }

        public async Task<UbConsumer?> GetByIdAsync(int consumerId)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                return await dataContext.UbConsumers
                .Include(x => x.UbConsumerConsents)
                .FirstOrDefaultAsync(x => x.Id == consumerId);
            }
        }

        public UbConsumer? GetConfirmedUbConsumerByEmail(string emailEncrypted)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                var users = dataContext.UbConsumers.Where(x => x.Email == emailEncrypted).OrderByDescending(x => x.DateCreated);

                if (users != null && users.Any())
                {
                    return users.FirstOrDefault(y => y.UbConsumerConsents.Any(z => z.OptInConfirmed));
                }
                return null;
            }
        }

        public async Task<UbConsumer?> SaveConsumerAsync(UbConsumer consumer)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                if (SkipSaveData)
                {
                    return null;
                }

                dataContext.Entry(consumer).State = consumer.Id == 0 ?
                    EntityState.Added :
                    EntityState.Modified;

                await dataContext.SaveChangesAsync().ConfigureAwait(false);
                return consumer;
            }
        }

        public List<UbConsumer> GetConsumersForSiteAndType(int siteId, string type)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                var result = (from cons in dataContext.UbConsumers
                              join cc in dataContext.UbConsumerConsents on cons.Id equals cc.ConsumerId
                              join consent in dataContext.UbConsents on cc.ConsentId equals consent.Id
                              join consenttype in dataContext.UbConsentTypes on consent.TypeId equals consenttype.Id
                              where (!cc.IsUnsubscribed || cc.IsUnsubscribed == false)
                                 && consenttype.Code == type /*& consent.SiteId == siteId*/
                              select cons).ToList();

                return result;
            }
        }

        public async Task RemoveConsumerAsync(int consumerId)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                var consumer = await dataContext.UbConsumers.FirstOrDefaultAsync(x => x.Id == consumerId).ConfigureAwait(false);

                if (consumer != null)
                {
                    dataContext.UbConsumers.Remove(consumer);
                    await dataContext.SaveChangesAsync().ConfigureAwait(false);
                }
            }
        }
    }
}