using Microsoft.EntityFrameworkCore;

namespace Essity.FutureProof.Infrastructure.Repositories.Implementations
{
    public class UbWordBlacklistRepository : BaseRepository, IUbWordBlacklistRepository
    {
        private readonly IDbContextFactory<DataContext> _dataContextFactory;

        public UbWordBlacklistRepository(IDbContextFactory<DataContext> dataContextFactory)
        {
            _dataContextFactory = dataContextFactory;
        }

        public List<string?> GetAll()
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                return dataContext.UbWordBlacklists.Select(d => d.Word).ToList();
            }
        }
    }
}