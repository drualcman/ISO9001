using ISO9001.GetNonConformityByAffectedProcess.BusinessObjects;
using ISO9001.GetNonConformityByAffectedProcess.Core.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.GetNonConformityByAffectedProcess.Core
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddGetNonConformityByAffectedProcessCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IGetNonConformityByAffectedProcessInputPort, GetNonConformityByAffectedProcessHandler>();

            return services;
        }
    }

}
