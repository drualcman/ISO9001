using ISO9001.AuditLogs.Repositories.AuditEventProvider;
using ISO9001.GetAllAuditLogs.BusinessObjects.Interfaces;
using ISO9001.GetAuditLogById.BusinessObjects.Interfaces;
using ISO9001.GetAuditLogsByAction.BusinessObjects.Interfaces;
using ISO9001.GetAuditLogsByEntityIdBusinessObjects.Interfaces;
using ISO9001.Interfaces.Interfaces;
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
            services.AddScoped<IGetAuditLogByIdRepository, GetAuditLogByIdRepository>();

            services.AddScoped<IAuditEventProvider, AuditLogEventProvider>();
            return services;
        }
    }
}
