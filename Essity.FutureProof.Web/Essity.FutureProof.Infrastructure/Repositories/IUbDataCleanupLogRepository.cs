using Essity.FutureProof.Infrastructure.Entities;
using Essity.FutureProof.Infrastructure.Enums;

namespace Essity.FutureProof.Infrastructure.Repositories
{
    public interface IUbDataCleanupLogRepository
    {
        Task<UbDataCleanupLog?> GetByIdAsync(int logId);

        Task<IEnumerable<UbDataCleanupLog>> GetByTypeAsync(DataCleanupType type);

        Task<IEnumerable<UbDataCleanupLog>> GetBySiteId(int siteId);

        Task<UbDataCleanupLog> AddAsync(UbDataCleanupLog log);

        Task<UbDataCleanupLog> UpdateAsync(UbDataCleanupLog log);

        Task<UbDataCleanupLog> SetCompletedAsync(int logId);
    }
}