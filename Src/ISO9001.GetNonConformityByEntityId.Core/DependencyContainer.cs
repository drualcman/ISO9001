using ISO9001.GetNonConformityByEntityId.BusinessObjects;
using ISO9001.GetNonConformityByEntityId.Core.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.GetNonConformityByEntityId.Core
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddGetNonConformityByEntityIdCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IGetNonConformityByEntityIdInputPort, GetNonConformityByEntityIdHandler>();

            return services;
        }
    }

}
