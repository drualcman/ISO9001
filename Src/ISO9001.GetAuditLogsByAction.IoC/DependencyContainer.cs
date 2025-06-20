using ISO9001.GetAuditLogsByAction.Core;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.GetAuditLogsByAction.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddGetAuditLogsByActionServices(this IServiceCollection services)
        {
            services.AddGetAuditLogsByActionCoreServices();
            return services;
        }
    }
}
