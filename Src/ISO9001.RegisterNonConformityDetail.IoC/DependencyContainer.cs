using ISO9001.RegisterNonConformityDetail.Core;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.RegisterNonConformityDetail.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRegisterNonConformityDetailServices
            (this IServiceCollection services)
        {
            services.AddRegisterNonConformityDetailCoreServices();
            return services;
        }
    }

}
