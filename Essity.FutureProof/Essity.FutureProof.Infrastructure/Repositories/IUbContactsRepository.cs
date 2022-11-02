using Essity.FutureProof.Infrastructure.Entities;

namespace Essity.FutureProof.Infrastructure.Repositories
{
    public interface IUbContactsRepository
    {
        Task SaveContactAsync(UbContact contact);

        Task RemoveContactAsync(int contactId);

        List<UbContact> GetContacts();
    }
}