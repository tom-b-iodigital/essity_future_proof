using Essity.FutureProof.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Essity.FutureProof.Infrastructure.Repositories.Implementations
{
    public class UbContestSubmissionsRepository : IUbContestSubmissionsRepository
    {
        private readonly IDbContextFactory<DataContext> _dataContextFactory;

        public UbContestSubmissionsRepository(IDbContextFactory<DataContext> dataContextFactory)
        {
            _dataContextFactory = dataContextFactory;
        }

        public async Task<IEnumerable<UbContestSubmission>> GetByCampaignIdAsync(int campaignId)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                return await dataContext.UbContestSubmissions
                .Where(x => x.CampaignId.Equals(campaignId))
                    .ToListAsync()
                    .ConfigureAwait(false);
            }
        }

        public async Task<int> RemoveByCampaignIdAsync(int campaignId)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                var submissions = await GetByCampaignIdAsync(campaignId).ConfigureAwait(false);

                if (!submissions.Any())
                {
                    return 0;
                }

                dataContext.UbContestSubmissions.RemoveRange(submissions);
                return await dataContext.SaveChangesAsync().ConfigureAwait(false);
            }
        }
    }
}