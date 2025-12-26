namespace Microsoft.Extensions.DependencyInjection;

public static partial class DependencyContainer
{
    public static IServiceCollection AddAuditReportCoreServices(this IServiceCollection services)
    {
        services.AddScoped<IGenerateAuditReportController, GenerateAuditReportController>();
        services.AddScoped<IGenerateAuditReportInputPort, GenerateAuditReportHandler>();
        services.AddScoped<IGenerateAuditReportOutputPort, GenerateAuditReportPresenter>();

        return services;
    }
}
