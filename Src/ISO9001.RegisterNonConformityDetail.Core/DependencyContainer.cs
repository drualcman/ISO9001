using ISO9001.RegisterNonConformityDetail.BusinessObjects.Interfaces;
using ISO9001.RegisterNonConformityDetail.Core.Handler;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.RegisterNonConformityDetail.Core
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRegisterNonConformityDetailCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IRegisterNonConformityDetailInputPort, RegisterNonConformityDetailHandler>();
            return services;
        }
    }
}
