using ISO9001.RegisterNonConformity.BusinessObjects.Interfaces;
using ISO9001.RegisterNonConformity.Core.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.RegisterNonConformity.Core
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRegisterNonConformityCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IRegisterNonConformityInputPort, RegisterNonConformityHandler>();
            return services;
        }
    }
}
