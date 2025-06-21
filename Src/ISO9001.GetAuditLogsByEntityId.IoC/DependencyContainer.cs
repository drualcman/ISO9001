using ISO9001.GetAuditLogsByEntityId.Core;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.GetAuditLogsByEntityId.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddGetAuditLogsByEntityIdServices(this IServiceCollection services)
        {
            services.AddGetAuditLogsByEntityIdCoreServices();
            return services;
        }

    }
}
