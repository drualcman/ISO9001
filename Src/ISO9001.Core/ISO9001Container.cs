namespace Microsoft.Extensions.DependencyInjection;

public static class ISO9001Container
{
    public static IServiceCollection AddISO9001Services(this IServiceCollection services)
    {
        services.AddAuditLogCoreServices();
        services.AddCustomerFeedbackCoreServices();
        services.AddIncidentReportCoreServices();
        services.AddNonConformityCoreServices();
        services.AddQualityDashboardCoreServices();
        services.AddAuditEventCoreServices();
        services.AddAuditReportCoreServices();
        services.AddReportingPresenterPdfServices();
        return services;
    }
}
