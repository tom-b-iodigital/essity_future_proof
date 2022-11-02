using Essity.FutureProof.Infrastructure.Entities;
using Essity.FutureProof.Infrastructure.Enums;
using Essity.FutureProof.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Essity.FutureProof.Infrastructure.Repositories.Implementations
{
    public class UbDataCleanupLogRepository : IUbDataCleanupLogRepository
    {
        private readonly IDbContextFactory<DataContext> _dataContextFactory;

        public UbDataCleanupLogRepository(IDbContextFactory<DataContext> dataContextFactory)
        {
            _dataContextFactory = dataContextFactory;
        }

        public async Task<UbDataCleanupLog?> GetByIdAsync(int logId)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                return await dataContext.UbDataCleanupLogs.FirstOrDefaultAsync(x => x.Id.Equals(logId));
            }
        }

        public async Task<IEnumerable<UbDataCleanupLog>> GetByTypeAsync(DataCleanupType type)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                return await dataContext.UbDataCleanupLogs.Where(x => x.Type == type).ToListAsync();
            }
        }

        public async Task<IEnumerable<UbDataCleanupLog>> GetBySiteId(int siteId)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                return await dataContext.UbDataCleanupLogs.Where(x => x.SiteId.Equals(siteId)).ToListAsync();
            }
        }

        public async Task<UbDataCleanupLog> AddAsync(UbDataCleanupLog log)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                dataContext.UbDataCleanupLogs.Add(log);
                await dataContext.SaveChangesAsync();

                return log;
            }
        }

        public async Task<UbDataCleanupLog> UpdateAsync(UbDataCleanupLog log)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                var dbLog = await GetByIdAsync(log.Id);

                if (dbLog == null)
                {
                    throw new DbEntityNotFoundException();
                }

                dataContext.Entry(dbLog).CurrentValues.SetValues(log);

                await dataContext.SaveChangesAsync();

                return dbLog;
            }
        }

        public async Task<UbDataCleanupLog> SetCompletedAsync(int logId)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                var dbLog = await GetByIdAsync(logId);

                if (dbLog == null)
                {
                    throw new DbEntityNotFoundException();
                }

                dbLog.CompletedAt = DateTime.Now;

                await dataContext.SaveChangesAsync();

                return dbLog;
            }
        }
    }
}