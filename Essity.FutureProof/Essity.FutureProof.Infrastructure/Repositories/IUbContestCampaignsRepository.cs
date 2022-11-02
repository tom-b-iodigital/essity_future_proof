using Essity.FutureProof.Infrastructure.Entities;

namespace Essity.FutureProof.Infrastructure.Repositories
{
    public interface IUbContestCampaignsRepository
    {
        Task<UbContestCampaign?> GetByIdAsync(int campaignId);

        Task<bool> AddAggregatedDataAsync(int campaignId, string serializedData);
    }
}