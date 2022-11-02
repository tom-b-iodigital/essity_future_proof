using Essity.FutureProof.Infrastructure.Entities;

namespace Essity.FutureProof.Infrastructure.Repositories
{
    public interface IUbEqualitySurveyRepository
    {
        Task SaveEqualitySurveyAsync(UbEqualitySurvey survey);
    }
}
