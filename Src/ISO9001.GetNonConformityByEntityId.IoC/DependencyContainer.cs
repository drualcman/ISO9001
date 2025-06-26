using ISO9001.GetNonConformityByEntityId.Core;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.GetNonConformityByEntityId.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddGetNonConformityByEntityIdServices(this IServiceCollection services)
        {
            services.AddGetNonConformityByEntityIdCoreServices();

            return services;
        }
    }

}
