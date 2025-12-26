namespace ISO9001.Database.InMemory;

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
