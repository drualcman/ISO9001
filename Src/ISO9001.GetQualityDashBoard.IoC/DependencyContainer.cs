using ISO9001.GetQualityDashBoard.Core;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.GetQualityDashBoard.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddGetQualityDashBoardServices(this IServiceCollection services)
        {
            services.AddGetQualityDashBoardCoreServices();
            return services;
        }
    }

}
