using ISO9001.GetNonConformityByStatus.Core;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.GetNonConformityByStatus.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddGetNonConformityByStatusServices(this IServiceCollection services)
        {
            services.AddGetNonConformityByStatusCoreServices();


            return services;
        }
    }

}
