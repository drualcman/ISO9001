using ISO9001.AuditLogs.Repositories.Interfaces;
using ISO9001.Database.InMemory.DataContexts;
using ISO9001.Database.InMemory.DataContexts.AuditLogDataContexts;
using ISO9001.RegisterCustomerFeedback.Repositories.Interfaces;
using ISO9001.RegisterIncidentReport.Repositories.Interfaces;
using ISO9001.RegisterNonConformityRepositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.Database.InMemory
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddDatabaseInMemory(this IServiceCollection services)
        {
            services.AddScoped<IRegisterAuditLogDataContext, InMemoryRegisterAuditLogDataContext>();
            services.AddScoped<IGetAuditLogsByActionDataContext, InMemoryGetAuditLogsByActionDataContext>();
            services.AddScoped<IGetAllAuditLogsDataContext, InMemoryGetAllAuditLogsDataContext>();
            services.AddScoped<IGetAuditLogsByEntityIdDataContext, InMemoryGetAuditLogsByEntityIdDataContext>();

            services.AddScoped<IRegisterCustomerFeedbackDataContext, InMemoryRegisterCustomerFeedbackDataContext>();

            services.AddScoped<IRegisterIncidentReportDataContext, InMemoryRegisterIncidentReportDataContext>();

            services.AddScoped<IRegisterNonConformityDataContext, InMemoryRegisterNonConformityDataContext>();

            return services;
        }
    }
}
