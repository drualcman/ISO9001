namespace Microsoft.Extensions.DependencyInjection;

public static partial class DependencyContainer
{
    public static IServiceCollection AddNonConformityCoreServices(this IServiceCollection services)
    {
        services.TryAddScoped<ICommandNonConformityRepository, CommandNonConformityRepository>();
        services.TryAddScoped<ICommandNonConformityDetailRepository, CommandNonConformityDetailRepository>();
        services.TryAddScoped<IQueryableNonConformityRepository, QueryableNonConformityRepository>();

        services.TryAddScoped<IAllNonConformitiesQuery, GetAllNonConformitiesHandler>();
        services.TryAddScoped<INonConformityByAffectedProcessQuery, GetNonConformityByAffectedProcessHandler>();
        services.TryAddScoped<INonConformityByEntityIdQuery, GetNonConformityByEntityIdHandler>();
        services.TryAddScoped<INonConformityByStatusQuery, GetNonConformityByStatusHandler>();
        services.TryAddScoped<IRegisterNonConformity, RegisterNonConformityHandler>();
        services.TryAddScoped<IRegisterNonConformityDetail, RegisterNonConformityDetailHandler>();

        services.TryAddScoped<IGenerateNonConformityMasterReport, GenerateNonConformityMasterReportController>();
        services.TryAddScoped<IGenerateNonConformityMasterReportInputPort, GenerateNonConformityMasterReportHandler>();
        services.TryAddScoped<IGenerateNonConformityMasterReportOutputPort, GenerateNonConformityMasterReportPresenter>();

        services.TryAddScoped<IGenerateNonConformityDetailsReport, GenerateNonConformityDetailsReportController>();
        services.TryAddScoped<IGenerateNonConformityDetailsReportInputPort, GenerateNonConformityDetailsReportHandler>();
        services.TryAddScoped<IGenerateNonConformityDetailsReportOutputPort, GenerateNonConformityDetailsReportPresenter>();
        return services;
    }
}
