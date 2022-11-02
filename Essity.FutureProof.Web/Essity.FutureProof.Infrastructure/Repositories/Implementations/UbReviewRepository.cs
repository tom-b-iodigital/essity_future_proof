using Essity.FutureProof.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Essity.FutureProof.Infrastructure.Repositories.Implementations
{
    public class UbReviewRepository : BaseRepository, IUbReviewRepository
    {
        private readonly IDbContextFactory<DataContext> _dataContextFactory;

        public UbReviewRepository(IDbContextFactory<DataContext> dataContextFactory)
        {
            _dataContextFactory = dataContextFactory;
        }

        public IEnumerable<UbReview> GetReviewsByProductId(int nodeId, bool visibleOnly = true)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                var allReviews = dataContext.UbReviews.Include("UbConsumer").Where(p => p.ProductId == nodeId);
                if (visibleOnly)
                {
                    return allReviews.Where(p => p.Visible).ToList();
                }

                return allReviews.ToList();
            }
        }

        public IEnumerable<UbReview> GetReviewsByProductIdWithFilter(int nodeId, string filter, bool? replyStatus, bool visibleOnly = true)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                if (replyStatus == false)
                {
                    var allReviews = dataContext.UbReviews.Include("UbConsumer").Where(p => p.ProductId == nodeId).Where(a => (a.Title ?? "").Contains(filter) || (a.UbConsumer.FirstName ?? "").Contains(filter)
               || (a.UbConsumer.LastName ?? "").Contains(filter) || (a.BrandReply ?? "").Contains(filter))
                        .Where(r => r.BrandReply == null);

                    if (visibleOnly)
                    {
                        return allReviews.Where(p => p.Visible).ToList();
                    }

                    return allReviews.ToList();
                }
                else if (replyStatus == true)
                {
                    var allReviews = dataContext.UbReviews.Include("UbConsumer").Where(p => p.ProductId == nodeId).Where(a => (a.Title ?? "").Contains(filter) || (a.UbConsumer.FirstName ?? "").Contains(filter)
               || (a.UbConsumer.LastName ?? "").Contains(filter) || (a.BrandReply ?? "").Contains(filter))
                        .Where(r => r.BrandReply != null);

                    if (visibleOnly)
                    {
                        return allReviews.Where(p => p.Visible).ToList();
                    }

                    return allReviews.ToList();
                }
                else
                {
                    var allReviews = dataContext.UbReviews.Include("UbConsumer").Where(p => p.ProductId == nodeId).Where(a => (a.Title ?? "").Contains(filter) || (a.UbConsumer.FirstName ?? "").Contains(filter)
                || (a.UbConsumer.LastName ?? "").Contains(filter) || (a.BrandReply ?? "").Contains(filter));

                    if (visibleOnly)
                    {
                        return allReviews.Where(p => p.Visible).ToList();
                    }

                    return allReviews.ToList();
                }
            }
        }

        public UbReview? GetReviewById(int reviewId)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                return dataContext.UbReviews.Include("UbConsumer").FirstOrDefault(p => p.ReviewId == reviewId);
            }
        }

        public async Task SaveReviewAsync(UbReview review)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                if (review != null)
                {
                    dataContext.UbReviews.Add(review);
                    await dataContext.SaveChangesAsync().ConfigureAwait(false);
                }
            }
        }

        public async Task RemoveReviewAsync(int reviewId)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                var review = await dataContext.UbReviews.FirstOrDefaultAsync(x => x.ReviewId == reviewId).ConfigureAwait(false);

                if (review != null)
                {
                    dataContext.UbReviews.Remove(review);
                    await dataContext.SaveChangesAsync().ConfigureAwait(false);
                }
            }
        }

        public async Task HideReviewAsync(int reviewId)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                var review = await dataContext.UbReviews.FirstOrDefaultAsync(x => x.ReviewId.Equals(reviewId)).ConfigureAwait(false);

                if (review != null)
                {
                    review.Visible = false;
                    await dataContext.SaveChangesAsync().ConfigureAwait(false);
                }
            }
        }

        public void ToggleVisibility(int reviewId, bool visible)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                var review = dataContext.UbReviews.Find(reviewId);

                if (review != null)
                {
                    review.Visible = visible;
                    dataContext.SaveChanges();
                }
            }
        }

        public bool UpdateReview(UbReview review)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                int result = dataContext.SaveChanges();

                return result == 1;
            }
        }
    }
}