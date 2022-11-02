using Essity.FutureProof.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Essity.FutureProof.Infrastructure.Repositories.Implementations
{
    public class UbEqualitySurveyRepository : BaseRepository, IUbEqualitySurveyRepository
    {
        private readonly IDbContextFactory<DataContext> _dataContextFactory;

        public UbEqualitySurveyRepository(IDbContextFactory<DataContext> dataContextFactory)
        {
            _dataContextFactory = dataContextFactory;
        }

        public async Task SaveEqualitySurveyAsync(UbEqualitySurvey survey)
        {
            using (DataContext dataContext = _dataContextFactory.CreateDbContext())
            {
                if (SkipSaveData)
                {
                    return;
                }

                if (survey.Id > 0)
                {
                    dataContext.UbEqualitySurveys.Attach(survey);
                }
                else
                {
                    dataContext.UbEqualitySurveys.Add(survey);
                }

                await dataContext.SaveChangesAsync().ConfigureAwait(false);
            }
        }
    }
}