using ISO9001.GetNonConformityByAffectedProcess.Core;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.GetNonConformityByAffectedProcess.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddGetNonConformityByAffectedProcessServices(this IServiceCollection services)
        {
            services.AddGetNonConformityByAffectedProcessCoreServices();
            return services;
        }
    }

}
