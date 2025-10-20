using ISO9001.AuditReport.Core.Interfaces;
using ISO9001.Repositories.AuditEvent;
using ISO9001.Repositories.AuditReport;

namespace ISO9001.Repositories
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddISO9001Repositories(this IServiceCollection services)
        {
            services.AddScoped<ICommandAuditLogRepository, CommandAuditLogRepository>();
            services.AddScoped<IQueryableAuditLogRepository, QueryableAuditLogRepository>();

            services.AddScoped<ICommandCustomerFeedbackRepository, CommandCustomerFeedbackRepository>();
            services.AddScoped<IQueryableCustomerFeedbackRepository, QueryableCustomerFeedbackRepository>();

            services.AddScoped<ICommandIncidentReportRepository, CommandIncidentReportRepository>();
            services.AddScoped<IQueryableIncidentReportRepository, QueryableIncidentReportRepository>();

            services.AddScoped<ICommandNonConformityRepository, CommandNonConformityRepository>();
            services.AddScoped<ICommandNonConformityDetailRepository, CommandNonConformityDetailRepository>();
            services.AddScoped<IQueryableNonConformityRepository, QueryableNonConformityRepository>();

            services.AddScoped<IQueryableQualityDashboardRepository, QueryableQualityDashboardRepository>();
            services.AddScoped<IQueryableAuditReportRepository, QueryableAuditReportRepository>();
            services.AddScoped<IQueryableAuditEventRepository, QueryableAuditEventRepository>();

            services.AddScoped<IAuditEventProvider, AuditLogEventProvider>();
            services.AddScoped<IAuditEventProvider, CustomerFeedbackEventProvider>();
            services.AddScoped<IAuditEventProvider, IncidentReportEventProvider>();
            services.AddScoped<IAuditEventProvider, NonConformityEventProvider>();
            return services;
        }
    }
}
