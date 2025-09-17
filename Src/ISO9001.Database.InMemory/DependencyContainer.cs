using ISO9001.Database.InMemory.DataContexts.AuditLogDataContexts;
using ISO9001.Database.InMemory.DataContexts.CustomerFeedbackDataContext;
using ISO9001.Database.InMemory.DataContexts.IncidentReportDataContext;
using ISO9001.Database.InMemory.DataContexts.NonConformityDataContext;
using ISO9001.Repositories.AuditLogRepositories.Interfaces;
using ISO9001.Repositories.CustomerFeedbackRepositories.Interfaces;
using ISO9001.Repositories.IncidentReportRepositories.Interfaces;
using ISO9001.Repositories.NonConformityRepositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.Database.InMemory
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddDatabaseInMemory(this IServiceCollection services)
        {
            services.AddSingleton<InMemoryAuditLogStore>();
            services.AddScoped<IWritableAuditLogDataContext, InMemoryWritableAuditLogDataContext>();
            services.AddScoped<IQueryableAuditLogDataContext, InMemoryQueryableAuditLogDataContext>();

            services.AddSingleton<InMemoryCustomerFeedbackStore>();
            services.AddScoped<IWritableCustomerFeedbackDataContext, InMemoryWritableCustomerFeedbackDataContext>();
            services.AddScoped<IQueryableCustomerFeedbackDataContext, InMemoryQueryableCustomerFeedbackDataContext>();

            services.AddSingleton<InMemoryIncidentReportStore>();
            services.AddScoped<IWritableIncidentReportDataContext, InMemoryWritableIncidentReportDataContext>();
            services.AddScoped<IQueryableIncidentReportDataContext, InMemoryQueryableIncidentReportDataContext>();

            services.AddSingleton<InMemoryNonConformityStore>();
            services.AddScoped<IWritableNonConformityDataContext, InMemoryWritableNonConformityDataContext>();
            services.AddScoped<IQueryableNonConformityDataContext, InMemoryQueryableNonConformityDataContext>();

            return services;
        }
    }
}
