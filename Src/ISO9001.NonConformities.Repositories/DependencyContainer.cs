using ISO9001.GetAllNonConformities.BusinessObjects;
using ISO9001.GetNonConformityByAffectedProcess.BusinessObjects;
using ISO9001.GetNonConformityByEntityId.BusinessObjects;
using ISO9001.GetNonConformityByStatus.BusinessObjects;
using ISO9001.RegisterNonConformity.BusinessObjects.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.NonConformities.Repositories
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddNonConformityRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<IRegisterNonConformityRepository, RegisterNonConformityRepository>();
            services.AddScoped<IGetAllNonConformitiesRepository, GetAllNonConformitiesRepository>();
            services.AddScoped<IGetNonConformityByAffectedProcessRepository, GetNonConformityByAffectedProcessRepository>();
            services.AddScoped<IGetNonConformityByEntityIdRepository, GetNonConformityByEntityIdRepository>();
            services.AddScoped<IGetNonConformityByStatusRepository, GetNonConformityByStatusRepository>();
            return services;
        }
    }
}
