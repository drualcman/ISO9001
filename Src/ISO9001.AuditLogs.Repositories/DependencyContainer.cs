using GOGO.ISO9001.GetAuditLogsByAction.BusinessObjects.Interfaces;
using ISO9001.GetAllAuditLogs.BusinessObjects;
using ISO9001.GetAuditLogsByEntityIdBusinessObjects.Interfaces;
using ISO9001.RegisterAuditLog.BusinessObjects.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.AuditLogs.Repositories
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddAuditLogsRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<IRegisterAuditLogRepository, RegisterAuditLogRepository>();
            services.AddScoped<IGetAllAuditLogsRepository, GetAllAuditLogsRepository>();
            services.AddScoped<IGetAuditLogsByEntityIdRepository, GetAuditLogsByEntityIdRepository>();
            services.AddScoped<IGetAuditLogsByActionRepository, GetAuditLogsByActionRepository>();

            return services;
        }
    }
}
