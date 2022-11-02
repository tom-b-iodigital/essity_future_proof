using Essity.FutureProof.Infrastructure.Entities;

namespace Essity.FutureProof.Infrastructure.Repositories
{
    public interface IUbProductTrackingsRepository
    {
        Task<IEnumerable<UbProductTracking>> GetTrackingsAsync(int siteId);

        Task SaveOrUpdateTrackingAsync(IEnumerable<UbProductTracking> productTrackings);

        Task RemoveTrackingAsync(IEnumerable<int> productTrackings);

        Task RemoveTrackingAsync(int siteId);

        Task ResetTrackingAsync(IEnumerable<string> productCodes);
    }
}
