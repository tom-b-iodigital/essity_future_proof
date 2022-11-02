using Essity.FutureProof.Connector.PCH.Services;
using Essity.FutureProof.Connector.PCH.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Essity.FutureProof.Connector.PCH.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddPCHConnectorServices(this IServiceCollection services)
        {
            services.AddTransient<IPchService, PchDdhService>();

            return services;
        }
    }
}