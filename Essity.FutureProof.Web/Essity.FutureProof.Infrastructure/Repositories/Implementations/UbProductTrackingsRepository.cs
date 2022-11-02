using Essity.FutureProof.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Essity.FutureProof.Infrastructure.Repositories.Implementations
{
    public class UbProductTrackingsRepository : BaseRepository, IUbProductTrackingsRepository
    {
        private readonly IDbContextFactory<DataContext> _dataContextFactory;

        public UbProductTrackingsRepository(IDbContextFactory<DataContext> dataContextFactory)
        {
            _dataContextFactory = dataContextFactory;
        }

        public async Task<IEnumerable<UbProductTracking>> GetTrackingsAsync(int siteId)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                return await dataContext.UbProductTrackings.Where(x => x.SiteId.Equals(siteId)).ToListAsync().ConfigureAwait(false);
            }
        }

        public async Task ResetTrackingAsync(IEnumerable<string> productCodes)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                foreach (var productCode in productCodes)
                {
                    var dbProductTrackings = await dataContext.UbProductTrackings.Where(x => x.GpimProductCode == productCode).ToArrayAsync().ConfigureAwait(false);

                    if (dbProductTrackings.Any())
                    {
                        dataContext.UbProductTrackings.RemoveRange(dbProductTrackings);
                    }
                }

                await dataContext.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        public async Task RemoveTrackingAsync(int siteId)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                dataContext.UbProductTrackings.RemoveRange(await GetTrackingsAsync(siteId).ConfigureAwait(false));
                await dataContext.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        public async Task RemoveTrackingAsync(IEnumerable<int> productTrackingIds)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                var dbProductTrackings = await GetTrackingsAsync(productTrackingIds).ConfigureAwait(false);

                if (dbProductTrackings.Any())
                {
                    dataContext.UbProductTrackings.RemoveRange(dbProductTrackings);
                }

                await dataContext.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        public async Task SaveOrUpdateTrackingAsync(IEnumerable<UbProductTracking> productTrackings)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                var productTrackingIds = productTrackings.Select(productTracking => productTracking.Id).ToArray();
                var dbProductTrackings = await GetTrackingsAsync(productTrackingIds).ConfigureAwait(false);

                foreach (var dbProductTracking in dbProductTrackings)
                {
                    dbProductTracking.HashCode = productTrackings.First(x => x.Id.Equals(dbProductTracking.Id)).HashCode;
                }

                var productTrackingsToAdd = productTrackings.Except(dbProductTrackings);
                if (productTrackingsToAdd.Any())
                {
                    dataContext.UbProductTrackings.AddRange(productTrackingsToAdd);
                }

                await dataContext.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        private async Task<IEnumerable<UbProductTracking>> GetTrackingsAsync(IEnumerable<int> productTrackingIds)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                return await dataContext.UbProductTrackings.Where(x => productTrackingIds.Contains(x.Id)).ToArrayAsync().ConfigureAwait(false);
            }
        }
    }
}