namespace Microsoft.Extensions.DependencyInjection;

public static partial class DependencyContainer
{
    public static IServiceCollection AddAuditEventCoreServices(this IServiceCollection services)
    {
        services.TryAddScoped<IQueryableAuditEventRepository, QueryableAuditEventRepository>();

        services.AddScoped<IAuditEventProvider, AuditLogEventProvider>();
        services.AddScoped<IAuditEventProvider, CustomerFeedbackEventProvider>();
        services.AddScoped<IAuditEventProvider, IncidentReportEventProvider>();
        services.AddScoped<IAuditEventProvider, NonConformityEventProvider>();

        services.TryAddScoped<IAuditEventQuery, GetAuditEventsHandler>();
        return services;
    }
}
