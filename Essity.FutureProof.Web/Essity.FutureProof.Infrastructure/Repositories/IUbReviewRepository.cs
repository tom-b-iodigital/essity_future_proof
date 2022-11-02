using Essity.FutureProof.Infrastructure.Entities;

namespace Essity.FutureProof.Infrastructure.Repositories
{
    public interface IUbReviewRepository
    {
        IEnumerable<UbReview> GetReviewsByProductId(int nodeId, bool visibleOnly = true);

        IEnumerable<UbReview> GetReviewsByProductIdWithFilter(int nodeId, string filter, bool? replyStatus, bool visibleOnly = true);

        UbReview? GetReviewById(int reviewId);

        Task SaveReviewAsync(UbReview review);

        Task RemoveReviewAsync(int reviewId);

        Task HideReviewAsync(int reviewId);

        void ToggleVisibility(int reviewId, bool visible);

        bool UpdateReview(UbReview review);
    }
}