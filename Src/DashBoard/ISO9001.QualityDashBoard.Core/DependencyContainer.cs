namespace ISO9001.QualityDashBoard.Core
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddQualityDashboardCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IGetQualityDashBoardInputPort, GetQualityDashBoardHandler>();

            return services;
        }
    }

}
