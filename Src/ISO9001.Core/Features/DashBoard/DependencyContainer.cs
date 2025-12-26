namespace Microsoft.Extensions.DependencyInjection;

public static partial class DependencyContainer
{
    public static IServiceCollection AddQualityDashboardCoreServices(this IServiceCollection services)
    {
        services.TryAddScoped<IQueryableQualityDashboardRepository, QueryableQualityDashboardRepository>();

        services.TryAddScoped<IGetQualityDashBoardInputPort, GetQualityDashBoardHandler>();

        return services;
    }
}
