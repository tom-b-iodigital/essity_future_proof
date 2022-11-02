using Essity.FutureProof.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Essity.FutureProof.Infrastructure.Repositories.Implementations
{
    public class UbWebLikesRepository : BaseRepository, IUbWebLikesRepository
    {
        private readonly IDbContextFactory<DataContext> _dataContextFactory;

        public UbWebLikesRepository(IDbContextFactory<DataContext> dataContextFactory)
        {
            _dataContextFactory = dataContextFactory;
        }

        public async Task<int> SaveWebLikeAsync(UbWebLike like)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                dataContext.UbWebLikes.Add(like);
                await dataContext.SaveChangesAsync().ConfigureAwait(false);

                return await GetLikeCountAsync(like.NodeId, like.IsLike).ConfigureAwait(false);
            }
        }

        public int GetLikeCount(int nodeId, bool isLike = true)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                return dataContext.UbWebLikes
                .Where(x => x.NodeId == nodeId && x.IsLike == isLike)
                .Count();
            }
        }

        public async Task<int> GetLikeCountAsync(int nodeId, bool isLike = true)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                return await dataContext.UbWebLikes
                .Where(x => x.NodeId == nodeId && x.IsLike == isLike)
                .CountAsync()
                .ConfigureAwait(false);
            }
        }

        public async Task<bool> HasUserVisitedAsync(int nodeId, string cookieName)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                return await dataContext.UbWebLikes
                .AnyAsync(x => x.NodeId == nodeId && (x.CookieName ?? "").Equals(cookieName))
                .ConfigureAwait(false);
            }
        }

        public Dictionary<int, int> GetLikesPerNodeId()
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                var likes = (from l in dataContext.UbWebLikes
                             select new { Key = l.NodeId, Value = dataContext.UbWebLikes.Count(x => x.NodeId == l.NodeId) }).ToList();

                var dict = new Dictionary<int, int>();

                foreach (var like in likes)
                {
                    if (!dict.ContainsKey(like.Key))
                    {
                        dict.Add(like.Key, like.Value);
                    }
                }

                return dict;
            }
        }
    }
}