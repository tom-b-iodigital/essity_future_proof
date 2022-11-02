using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Essity.FutureProof.Infrastructure.Repositories.Implementations
{
    public class UbContestCodesRepository : BaseRepository, IUbContestCodesRepository
    {
        private readonly IDbContextFactory<DataContext> _dataContextFactory;

        public UbContestCodesRepository(IDbContextFactory<DataContext> dataContextFactory)
        {
            _dataContextFactory = dataContextFactory;
        }

        public async Task<int> CampaignCodesCountAsync(int campaignId)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                return await dataContext.UbContestCodes
                .Where(x => x.CampaignId.Equals(campaignId))
                .CountAsync()
                .ConfigureAwait(false);
            }
        }

        public async Task<int> RemoveAllByCampaignIdAsync(int campaignId, int batchSize)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                var affected = 0;

                var commandTimeout = dataContext.Database.GetCommandTimeout();
                dataContext.Database.SetCommandTimeout(120);

                do
                {
                    var codes = await dataContext.UbContestCodes
                        .Where(x => x.CampaignId.Equals(campaignId))
                        .Take(batchSize)
                        .ToListAsync()
                        .ConfigureAwait(false);

                    dataContext.UbContestCodes.RemoveRange(codes);

                    affected += await dataContext
                        .SaveChangesAsync()
                        .ConfigureAwait(false);
                }
                while (dataContext.UbContestCodes.Any(x => x.CampaignId.Equals(campaignId)));

                dataContext.Database.SetCommandTimeout(commandTimeout);

                return affected;
            }
        }

        public async Task<int> BatchRemoveByCampaignIdAsync(int campaignId, int batchSize)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                var commandTimeout = dataContext.Database.GetCommandTimeout();
                dataContext.Database.SetCommandTimeout(120);

                var codes = await dataContext.UbContestCodes
                    .Where(x => x.CampaignId.Equals(campaignId))
                    .Take(batchSize)
                    .ToListAsync()
                    .ConfigureAwait(false);

                dataContext.UbContestCodes.RemoveRange(codes);

                var affected = await dataContext
                    .SaveChangesAsync()
                    .ConfigureAwait(false);

                dataContext.Database.SetCommandTimeout(commandTimeout);

                return affected;
            }
        }

        public async Task<int> BatchRemoveByCampaignIdWithRawQueryAsync(int campaignId, int batchSize)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                var commandTimeout = dataContext.Database.GetCommandTimeout();
                dataContext.Database.SetCommandTimeout(120);

                var query = @"DELETE TOP(@batchSize) FROM [dbo].[UbContestCodes]
                            WHERE [CampaignId] = @campaignId;";

                var affected = await dataContext
                    .Database.ExecuteSqlRawAsync(
                        query,
                        new SqlParameter("@batchSize", batchSize),
                        new SqlParameter("@campaignId", campaignId))
                    .ConfigureAwait(false);

                dataContext.Database.SetCommandTimeout(commandTimeout);

                return affected;
            }
        }
    }
}