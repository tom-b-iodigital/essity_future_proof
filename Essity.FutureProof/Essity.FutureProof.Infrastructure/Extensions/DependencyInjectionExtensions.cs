using Essity.FutureProof.Infrastructure.Repositories;
using Essity.FutureProof.Infrastructure.Repositories.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Essity.FutureProof.Infrastructure.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddInfraStructureServices(this IServiceCollection services)
        {
            services.AddTransient<IDataCleanupRepository, DataCleanupRepository>();
            services.AddTransient<IUbConsentsRepository, UbConsentsRepository>();
            services.AddTransient<IUbConsentTypesRepository, UbConsentTypesRepository>();
            services.AddTransient<IUbConsumersRepository, UbConsumersRepository>();
            services.AddTransient<IUbContactsRepository, UbContactsRepository>();
            services.AddTransient<IUbContestCampaignsRepository, UbContestCampaignsRepository>();
            services.AddTransient<IUbContestCodesRepository, UbContestCodesRepository>();
            services.AddTransient<IUbContestRepository, UbContestRepository>();
            services.AddTransient<IUbContestSubmissionsRepository, UbContestSubmissionsRepository>();
            services.AddTransient<IUbDataCleanupLogRepository, UbDataCleanupLogRepository>();
            services.AddTransient<IUbEqualitySurveyRepository, UbEqualitySurveyRepository>();
            services.AddTransient<IUbProductTrackingsRepository, UbProductTrackingsRepository>();
            services.AddTransient<IUbReviewRepository, UbReviewRepository>();
            services.AddTransient<IUbWebLikesRepository, UbWebLikesRepository>();
            services.AddTransient<IUbWordBlacklistRepository, UbWordBlacklistRepository>();

            return services;
        }
    }
}