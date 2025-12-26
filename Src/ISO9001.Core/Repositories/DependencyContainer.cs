namespace Microsoft.Extensions.DependencyInjection;

public static partial class DependencyContainer
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
