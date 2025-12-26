namespace Microsoft.Extensions.DependencyInjection;

public static partial class DependencyContainer
{
    public static IServiceCollection AddAuditReportCoreServices(this IServiceCollection services)
    {
        services.TryAddScoped<IQueryableAuditReportRepository, QueryableAuditReportRepository>();
        services.TryAddScoped<IGenerateAuditReport, GenerateAuditReportController>();
        services.TryAddScoped<IGenerateAuditReportInputPort, GenerateAuditReportHandler>();
        services.TryAddScoped<IGenerateAuditReportOutputPort, GenerateAuditReportPresenter>();

        return services;
    }
}
