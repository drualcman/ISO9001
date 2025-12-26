namespace Microsoft.Extensions.DependencyInjection;

public static partial class DependencyContainer
{
    public static IServiceCollection AddNonConformityCoreServices(this IServiceCollection services)
    {
        services.TryAddScoped<ICommandNonConformityRepository, CommandNonConformityRepository>();
        services.TryAddScoped<ICommandNonConformityDetailRepository, CommandNonConformityDetailRepository>();
        services.TryAddScoped<IQueryableNonConformityRepository, QueryableNonConformityRepository>();

        services.TryAddScoped<IGetAllNonConformitiesInputPort, GetAllNonConformitiesHandler>();
        services.TryAddScoped<IGetNonConformityByAffectedProcessInputPort, GetNonConformityByAffectedProcessHandler>();
        services.TryAddScoped<IGetNonConformityByEntityIdInputPort, GetNonConformityByEntityIdHandler>();
        services.TryAddScoped<IGetNonConformityByStatusInputPort, GetNonConformityByStatusHandler>();
        services.TryAddScoped<IRegisterNonConformityInputPort, RegisterNonConformityHandler>();
        services.TryAddScoped<IRegisterNonConformityDetailInputPort, RegisterNonConformityDetailHandler>();

        services.TryAddScoped<IGenerateNonConformityMasterReportController, GenerateNonConformityMasterReportController>();
        services.TryAddScoped<IGenerateNonConformityMasterReportInputPort, GenerateNonConformityMasterReportHandler>();
        services.TryAddScoped<IGenerateNonConformityMasterReportOutputPort, GenerateNonConformityMasterReportPresenter>();

        services.TryAddScoped<IGenerateNonConformityDetailsReportController, GenerateNonConformityDetailsReportController>();
        services.TryAddScoped<IGenerateNonConformityDetailsReportInputPort, GenerateNonConformityDetailsReportHandler>();
        services.TryAddScoped<IGenerateNonConformityDetailsReportOutputPort, GenerateNonConformityDetailsReportPresenter>();
        return services;
    }
}
