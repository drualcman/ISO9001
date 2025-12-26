namespace Microsoft.Extensions.DependencyInjection;

public static partial class DependencyContainer
{
    public static IServiceCollection AddAuditLogCoreServices(this IServiceCollection services)
    {
        services.TryAddScoped<ICommandAuditLogRepository, CommandAuditLogRepository>();
        services.TryAddScoped<IQueryableAuditLogRepository, QueryableAuditLogRepository>();

        services.TryAddScoped<IRegisterAuditLog, RegisterAuditLogHandler>();
        services.TryAddScoped<IAuditLogsByEntityIdQuery, GetAuditLogsByEntityIdHandler>();
        services.TryAddScoped<IAuditLogsByActionQuery, GetAuditLogsByActionHandler>();
        services.TryAddScoped<IAuditLogByIdQuery, GetAuditLogByIdHandler>();
        services.TryAddScoped<IAllAuditLogsQuery, GetAllAuditLogsHandler>();

        services.TryAddScoped<IGenerateAuditLogReport, GenerateAuditLogReportController>();
        services.TryAddScoped<IGenerateAuditLogReportOutputPort, GenerateAuditLogReportPresenter>();
        services.TryAddScoped<IGenerateAuditLogReportInputPort, GenerateAuditLogReportHandler>();
        return services;
    }
}
