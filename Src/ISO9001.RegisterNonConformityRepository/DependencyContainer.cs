using ISO9001.RegisterNonConformity.BusinessObjects.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.RegisterNonConformityRepositories
{
    public static class DependencyContainer
    {
        public static IServiceCollection RegisterNonConformityRepositoryService(this IServiceCollection services)
        {
            services.AddScoped<IRegisterNonConformityRepository, RegisterNonConformityRepository>();
            return services;
        }
    }
}
