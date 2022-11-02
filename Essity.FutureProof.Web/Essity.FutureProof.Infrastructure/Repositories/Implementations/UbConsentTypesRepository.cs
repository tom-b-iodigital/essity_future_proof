using Essity.FutureProof.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Essity.FutureProof.Infrastructure.Repositories.Implementations
{
    public class UbConsentTypesRepository : BaseRepository, IUbConsentTypesRepository
    {
        private readonly IDbContextFactory<DataContext> _dataContextFactory;

        public UbConsentTypesRepository(IDbContextFactory<DataContext> dataContextFactory)
        {
            _dataContextFactory = dataContextFactory;
        }

        public UbConsentType? GetConsentTypesById(int id)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                return dataContext.UbConsentTypes.FirstOrDefault(x => x.Id == id);
            }
        }
    }
}