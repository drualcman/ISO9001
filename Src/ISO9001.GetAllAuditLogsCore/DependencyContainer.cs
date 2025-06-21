using ISO9001.GetAllAuditLogs.BusinessObjects;
using ISO9001.GetAllAuditLogsCore.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.GetAllAuditLogsCore
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddGetAllAuditLogsCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IGetAllAuditLogsInputPort, GetAllAuditLogsHandler>();
            return services;
        }
    }
}
