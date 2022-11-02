namespace Essity.FutureProof.Infrastructure.Repositories
{
    public interface IUbContestCodesRepository
    {
        Task<int> CampaignCodesCountAsync(int campaignId);

        Task<int> RemoveAllByCampaignIdAsync(int campaignId, int batchSize);

        Task<int> BatchRemoveByCampaignIdAsync(int campaignId, int batchSize);

        Task<int> BatchRemoveByCampaignIdWithRawQueryAsync(int campaignId, int batchSize);
    }
}