using Essity.FutureProof.Infrastructure.Entities;

namespace Essity.FutureProof.Infrastructure.Repositories
{
    public interface IUbConsumersRepository
    {
        UbConsumer? GetById(int consumerId);

        Task<UbConsumer?> GetByIdAsync(int consumerId);

        UbConsumer? GetConfirmedUbConsumerByEmail(string emailEncrypted);

        Task<UbConsumer?> SaveConsumerAsync(UbConsumer consumer);

        List<UbConsumer> GetConsumersForSiteAndType(int siteId, string type);

        Task RemoveConsumerAsync(int consumerId);
    }
}