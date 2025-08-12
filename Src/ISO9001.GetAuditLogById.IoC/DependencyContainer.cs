using ISO9001.GetAuditLogById.Core;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.GetAuditLogById.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddGetAuditLogByIdServices(this IServiceCollection services)
        {
            services.AddGetAuditLogByIdCoreServices();

            return services;
        }
    }

}
