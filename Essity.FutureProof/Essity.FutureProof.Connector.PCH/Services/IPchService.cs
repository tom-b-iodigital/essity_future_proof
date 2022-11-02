using Essity.FutureProof.Connector.PCH.Config;
using Essity.FutureProof.Domain.Interfaces;
using Essity.FutureProof.Domain.Models;

namespace Essity.FutureProof.Connector.PCH.Services
{
    public interface IPchService
    {
        Task<CommunicationResult<T>> GetProducts<T>(PchSettingElement setting, string catalog, string lang, string brand)
            where T : IDomainProduct;
    }
}