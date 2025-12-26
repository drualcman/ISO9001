namespace Microsoft.Extensions.DependencyInjection;

public static partial class DependencyContainer
{
    public static IServiceCollection AddQualityDashboardCoreServices(this IServiceCollection services)
    {
        services.AddScoped<IGetQualityDashBoardInputPort, GetQualityDashBoardHandler>();

        return services;
    }
}
