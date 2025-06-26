using ISO9001.RegisterNonConformity.Core;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.RegisterNonConformityIoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRegisterNonConformityServices(this IServiceCollection services)
        {
            services.AddRegisterNonConformityCoreServices();
            return services;
        }
    }
}
