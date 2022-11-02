using Essity.FutureProof.Infrastructure.Entities;

namespace Essity.FutureProof.Infrastructure.Repositories
{
    public interface IUbWebLikesRepository
    {
        Task<int> SaveWebLikeAsync(UbWebLike like);

        int GetLikeCount(int nodeId, bool isLike = true);

        Task<int> GetLikeCountAsync(int nodeId, bool isLike = true);

        Task<bool> HasUserVisitedAsync(int nodeId, string cookieName);

        Dictionary<int, int> GetLikesPerNodeId();
    }
}
