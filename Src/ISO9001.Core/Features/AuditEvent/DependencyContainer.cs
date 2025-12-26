namespace Microsoft.Extensions.DependencyInjection;

public static partial class DependencyContainer
{
    public static IServiceCollection AddAuditEventCoreServices(this IServiceCollection services)
    {
        services.TryAddScoped<IQueryableAuditEventRepository, QueryableAuditEventRepository>();

        services.TryAddScoped<IAuditEventProvider, AuditLogEventProvider>();
        services.TryAddScoped<IAuditEventProvider, CustomerFeedbackEventProvider>();
        services.TryAddScoped<IAuditEventProvider, IncidentReportEventProvider>();
        services.TryAddScoped<IAuditEventProvider, NonConformityEventProvider>();

        services.TryAddScoped<IGetAuditEventInputPort, GetAuditEventsHandler>();
        return services;
    }
}
