using ISO9001.GetAllAuditLogsCore;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.GetAllAuditLogs.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddGetAllAuditLogsServices(this IServiceCollection services)
        {
            services.AddGetAllAuditLogsCoreServices();
            return services;
        }
    }
}
