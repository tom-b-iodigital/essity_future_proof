using System.Threading.Tasks;
using Essity.ConsumerTissue.Connector.PCH.Config;
using Essity.ConsumerTissue.Domain.Interfaces;
using Essity.ConsumerTissue.Domain.Models;

namespace Essity.ConsumerTissue.Connector.PCH.Services
{
    public interface IPchService
    {
        Task<CommunicationResult<T>> GetProducts<T>(PchSettingElement setting, string catalog, string lang, string brand)
            where T : IDomainProduct;
    }
}