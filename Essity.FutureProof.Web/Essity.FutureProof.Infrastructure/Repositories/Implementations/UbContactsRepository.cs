using Essity.FutureProof.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Essity.FutureProof.Infrastructure.Repositories.Implementations
{
    public class UbContactsRepository : BaseRepository, IUbContactsRepository
    {
        private readonly IDbContextFactory<DataContext> _dataContextFactory;

        public UbContactsRepository(IDbContextFactory<DataContext> dataContextFactory)
        {
            _dataContextFactory = dataContextFactory;
        }

        public async Task SaveContactAsync(UbContact contact)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                if (SkipSaveData)
                {
                    return;
                }

                if (contact.Id > 0)
                {
                    dataContext.UbContacts.Attach(contact);
                }
                else
                {
                    dataContext.UbContacts.Add(contact);
                }

                await dataContext.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        public async Task RemoveContactAsync(int contactId)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                if (contactId > 0)
                {
                    var contact = await dataContext.UbContacts.FirstOrDefaultAsync(x => x.Id == contactId).ConfigureAwait(false);

                    if (contact != null)
                    {
                        dataContext.UbContacts.Remove(contact);
                        await dataContext.SaveChangesAsync().ConfigureAwait(false);
                    }
                }
            }
        }

        public List<UbContact> GetContacts()
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                return dataContext.UbContacts.ToList();
            }
        }
    }
}