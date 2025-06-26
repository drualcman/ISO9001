using ISO9001.GetNonConformityByStatus.BusinessObjects;
using ISO9001.GetNonConformityByStatus.Core.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.GetNonConformityByStatus.Core
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddGetNonConformityByStatusCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IGetNonConformityByStatusInputPort, GetNonConformityByStatusHandler>();

            return services;
        }
    }

}
