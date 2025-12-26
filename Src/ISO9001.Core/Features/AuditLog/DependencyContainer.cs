namespace Microsoft.Extensions.DependencyInjection;

public static partial class DependencyContainer
{
    public static IServiceCollection AddAuditLogCoreServices(this IServiceCollection services)
    {
        services.AddScoped<IRegisterAuditLogInputPort, RegisterAuditLogHandler>();
        services.AddScoped<IGetAuditLogsByEntityIdInputPort, GetAuditLogsByEntityIdHandler>();
        services.AddScoped<IGetAuditLogsByActionInputPort, GetAuditLogsByActionHandler>();
        services.AddScoped<IGetAuditLogByIdInputPort, GetAuditLogByIdHandler>();
        services.AddScoped<IGetAllAuditLogsInputPort, GetAllAuditLogsHandler>();

        services.AddScoped<IGenerateAuditLogReportController, GenerateAuditLogReportController>();
        services.AddScoped<IGenerateAuditLogReportOutputPort, GenerateAuditLogReportPresenter>();
        services.AddScoped<IGenerateAuditLogReportInputPort, GenerateAuditLogReportHandler>();
        return services;
    }
}
