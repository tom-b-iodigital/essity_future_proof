using Essity.FutureProof.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Essity.FutureProof.Infrastructure.Repositories.Implementations
{
    public class UbContestCampaignsRepository : BaseRepository, IUbContestCampaignsRepository
    {
        private readonly IDbContextFactory<DataContext> _dataContextFactory;

        public UbContestCampaignsRepository(IDbContextFactory<DataContext> dataContextFactory)
        {
            _dataContextFactory = dataContextFactory;
        }

        public async Task<UbContestCampaign?> GetByIdAsync(int campaignId)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                return await dataContext.UbContestCampaigns.FirstOrDefaultAsync(x => x.Id.Equals(campaignId)).ConfigureAwait(false);
            }
        }

        public async Task<bool> AddAggregatedDataAsync(int campaignId, string serializedData)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                var campaign = await GetByIdAsync(campaignId).ConfigureAwait(false);
                if (campaign != null)
                {
                    campaign.AggregatedData = serializedData;
                }

                var affected = await dataContext.SaveChangesAsync().ConfigureAwait(false);

                return affected > 0;
            }
        }
    }
}