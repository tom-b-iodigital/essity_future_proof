namespace Essity.FutureProof.Infrastructure.Repositories
{
    public interface IUbWordBlacklistRepository
    {
        List<string?> GetAll();
    }
}