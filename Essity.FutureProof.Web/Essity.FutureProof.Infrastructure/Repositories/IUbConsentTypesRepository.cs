using Essity.FutureProof.Infrastructure.Entities;

namespace Essity.FutureProof.Infrastructure.Repositories
{
    public interface IUbConsentTypesRepository
    {
        UbConsentType? GetConsentTypesById(int id);
    }
}