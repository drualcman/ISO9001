using ISO9001.GetAllNonConformities.Core;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.GetAllNonConformities.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddGetAllNonConformitiesServices(this IServiceCollection services)
        {
            services.AddGetAllNonConformitiesCoreServices();
            return services;
        }
    }

}
