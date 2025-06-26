using ISO9001.GetAllNonConformities.BusinessObjects;
using ISO9001.GetAllNonConformities.Core.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.GetAllNonConformities.Core
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddGetAllNonConformitiesCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IGetAllNonConformitiesInputPort, GetAllNonConformitiesHandler>();
            return services;
        }
    }

}
