using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ISO9001.Database.InMemory;

public static class DependencyContainer
{
    public static IServiceCollection AddDatabaseInMemory(this IServiceCollection services)
    {
        services.TryAddSingleton<InMemoryAuditLogStore>();
        services.TryAddScoped<IWritableAuditLogDataContext, InMemoryWritableAuditLogDataContext>();
        services.TryAddScoped<IQueryableAuditLogDataContext, InMemoryQueryableAuditLogDataContext>();

        services.TryAddSingleton<InMemoryCustomerFeedbackStore>();
        services.TryAddScoped<IWritableCustomerFeedbackDataContext, InMemoryWritableCustomerFeedbackDataContext>();
        services.TryAddScoped<IQueryableCustomerFeedbackDataContext, InMemoryQueryableCustomerFeedbackDataContext>();

        services.TryAddSingleton<InMemoryIncidentReportStore>();
        services.TryAddScoped<IWritableIncidentReportDataContext, InMemoryWritableIncidentReportDataContext>();
        services.TryAddScoped<IQueryableIncidentReportDataContext, InMemoryQueryableIncidentReportDataContext>();

        services.TryAddSingleton<InMemoryNonConformityStore>();
        services.TryAddScoped<IWritableNonConformityDataContext, InMemoryWritableNonConformityDataContext>();
        services.TryAddScoped<IQueryableNonConformityDataContext, InMemoryQueryableNonConformityDataContext>();

        return services;
    }
}
