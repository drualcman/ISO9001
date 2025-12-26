namespace Microsoft.Extensions.DependencyInjection;

public static partial class DependencyContainer
{
    public static IServiceCollection AddIncidentReportCoreServices(this IServiceCollection services)
    {
        services.TryAddScoped<ICommandIncidentReportRepository, CommandIncidentReportRepository>();
        services.TryAddScoped<IQueryableIncidentReportRepository, QueryableIncidentReportRepository>();

        services.TryAddScoped<IAllIncidentReportsQuery, GetAllIncidentReportsHandler>();
        services.TryAddScoped<IGetIncidentReportByIdInputPort, GetIncidentReportByIdHandler>();
        services.TryAddScoped<IIncidentReportByEntityIdQuery, GetIncidentReportByEntityIdHandler>();
        services.TryAddScoped<IRegisterIncidentReport, RegisterIncidentReportHandler>();

        services.TryAddScoped<IGenerateIncidentReportReport, GenerateIncidentReportReportController>();
        services.TryAddScoped<IGenerateIncidentReportReportInputPort, GenerateIncidentReportReportHandler>();
        services.TryAddScoped<IGenerateIncidentReportReportOutputPort, GenerateIncidentReportReportPresenter>();
        return services;
    }
}
