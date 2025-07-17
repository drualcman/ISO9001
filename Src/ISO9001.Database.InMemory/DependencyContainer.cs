using ISO9001.AuditLogs.Repositories.Interfaces;
using ISO9001.CustomerFeedbacks.Repositories.Interfaces;
using ISO9001.Database.InMemory.DataContexts;
using ISO9001.Database.InMemory.DataContexts.AuditLogDataContexts;
using ISO9001.Database.InMemory.DataContexts.CustomerFeedbackDataContext;
using ISO9001.Database.InMemory.DataContexts.IncidentReportDataContext;
using ISO9001.Database.InMemory.DataContexts.NonConformityDataContext;
using ISO9001.IncidentReports.Repositories.Interfaces;
using ISO9001.NonConformities.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.Database.InMemory
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddDatabaseInMemory(this IServiceCollection services)
        {
            services.AddScoped<IWritableAuditLogDataContext, InMemoryWritableAuditLogDataContext>();
            services.AddScoped<IQueryableAuditLogDataContext, InMemoryQueryableAuditLogDataContext>();

            services.AddScoped<IWritableCustomerFeedbackDataContext, InMemoryWritableCustomerFeedbackDataContext>();
            services.AddScoped<IQueryableCustomerFeedbackDataContext, InMemoryQueryableCustomerFeedbackDataContext>();

            services.AddScoped<IWritableIncidentReportDataContext, InMemoryWritableIncidentReportDataContext>();
            services.AddScoped<IQueryableIncidentReportDataContext, InMemoryQueryableIncidentReportDataContext>();

            services.AddScoped<IWritableNonConformityDataContext, InMemoryWritableNonConformityDataContext>();
            services.AddScoped<IQueryableNonConformityDataContext, InMemoryQueryableNonConformityDataContext>();

            return services;
        }
    }
}
