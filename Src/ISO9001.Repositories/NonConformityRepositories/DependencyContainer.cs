using ISO9001.GetAllNonConformities.BusinessObjects;
using ISO9001.GetNonConformityByAffectedProcess.BusinessObjects;
using ISO9001.GetNonConformityByEntityId.BusinessObjects;
using ISO9001.GetNonConformityByStatus.BusinessObjects;
using ISO9001.Interfaces.Interfaces;
using ISO9001.RegisterNonConformity.BusinessObjects.Interfaces;
using ISO9001.RegisterNonConformityDetail.BusinessObjects.Interfaces;
using ISO9001.Repositories.NonConformityRepositories.AuditEventProvider;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.Repositories.NonConformityRepositories
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddNonConformityRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<IRegisterNonConformityRepository, RegisterNonConformityRepository>();
            services.AddScoped<IRegisterNonConformityDetailRepository, RegisterNonConformityDetailRepository>();
            services.AddScoped<IGetAllNonConformitiesRepository, GetAllNonConformitiesRepository>();
            services.AddScoped<IGetNonConformityByAffectedProcessRepository, GetNonConformityByAffectedProcessRepository>();
            services.AddScoped<IGetNonConformityByEntityIdRepository, GetNonConformityByEntityIdRepository>();
            services.AddScoped<IGetNonConformityByStatusRepository, GetNonConformityByStatusRepository>();

            services.AddScoped<IAuditEventProvider, NonConformityEventProvider>();
            return services;
        }
    }
}
