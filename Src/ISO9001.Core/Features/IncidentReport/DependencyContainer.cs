namespace Microsoft.Extensions.DependencyInjection;

public static partial class DependencyContainer
{
    public static IServiceCollection AddIncidentReportCoreServices(this IServiceCollection services)
    {
        services.TryAddScoped<ICommandIncidentReportRepository, CommandIncidentReportRepository>();
        services.TryAddScoped<IQueryableIncidentReportRepository, QueryableIncidentReportRepository>();

        services.TryAddScoped<IGetAllIncidentReportsInputPort, GetAllIncidentReportsHandler>();
        services.TryAddScoped<IGetIncidentReportByIdInputPort, GetIncidentReportByIdHandler>();
        services.TryAddScoped<IGetIncidentReportByEntityIdInputPort, GetIncidentReportByEntityIdHandler>();
        services.TryAddScoped<IRegisterIncidentReportInputPort, RegisterIncidentReportHandler>();

        services.TryAddScoped<IGenerateIncidentReportReportController, GenerateIncidentReportReportController>();
        services.TryAddScoped<IGenerateIncidentReportReportInputPort, GenerateIncidentReportReportHandler>();
        services.TryAddScoped<IGenerateIncidentReportReportOutputPort, GenerateIncidentReportReportPresenter>();
        return services;
    }
}
