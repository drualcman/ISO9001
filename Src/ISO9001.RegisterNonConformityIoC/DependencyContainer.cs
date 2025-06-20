using ISO9001.RegisterNonConformity.Core;
using ISO9001.RegisterNonConformityRepositories;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.RegisterNonConformityIoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRegisterNonConformityServices(this IServiceCollection services)
        {
            services.AddRegisterNonConformityCoreServices();
            services.RegisterNonConformityRepositoryService();
            return services;
        }
    }
}
