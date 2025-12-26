namespace Microsoft.Extensions.DependencyInjection;

public static partial class DependencyContainer
{
    public static IServiceCollection AddAuditLogCoreServices(this IServiceCollection services)
    {
        services.TryAddScoped<ICommandAuditLogRepository, CommandAuditLogRepository>();
        services.TryAddScoped<IQueryableAuditLogRepository, QueryableAuditLogRepository>();

        services.TryAddScoped<IRegisterAuditLogInputPort, RegisterAuditLogHandler>();
        services.TryAddScoped<IGetAuditLogsByEntityIdInputPort, GetAuditLogsByEntityIdHandler>();
        services.TryAddScoped<IGetAuditLogsByActionInputPort, GetAuditLogsByActionHandler>();
        services.TryAddScoped<IGetAuditLogByIdInputPort, GetAuditLogByIdHandler>();
        services.TryAddScoped<IGetAllAuditLogsInputPort, GetAllAuditLogsHandler>();

        services.TryAddScoped<IGenerateAuditLogReportController, GenerateAuditLogReportController>();
        services.TryAddScoped<IGenerateAuditLogReportOutputPort, GenerateAuditLogReportPresenter>();
        services.TryAddScoped<IGenerateAuditLogReportInputPort, GenerateAuditLogReportHandler>();
        return services;
    }
}
