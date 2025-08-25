using ISO9001.GetQualityDashBoard.BusinessObjects.Interfaces;
using ISO9001.GetQualityDashBoard.Core.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.GetQualityDashBoard.Core
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddGetQualityDashBoardCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IGetQualityDashBoardInputPort, GetQualityDashBoardHandler>();
            return services;
        }
    }

}
