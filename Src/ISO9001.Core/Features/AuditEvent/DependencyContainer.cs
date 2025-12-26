namespace Microsoft.Extensions.DependencyInjection;

public static partial class DependencyContainer
{
    public static IServiceCollection AddAuditEventCoreServices(this IServiceCollection services)
    {
        services.AddScoped<IGetAuditEventsInputPort, GetAuditEventsHandler>();
        return services;
    }
}
