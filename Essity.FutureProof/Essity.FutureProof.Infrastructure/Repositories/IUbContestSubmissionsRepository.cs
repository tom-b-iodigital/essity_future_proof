using Essity.FutureProof.Infrastructure.Entities;

namespace Essity.FutureProof.Infrastructure.Repositories
{
    public interface IUbContestSubmissionsRepository
    {
        Task<IEnumerable<UbContestSubmission>> GetByCampaignIdAsync(int campaignId);

        Task<int> RemoveByCampaignIdAsync(int campaignId);
    }
}