using ISO9001.RegisterIncidentReport.Core;
using ISO9001.RegisterIncidentReport.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.RegisterIncidentReportIoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRegisterIncidentReportServices(
            this IServiceCollection services)
        {

            services.AddRegisterIncidentReportRepositoryService();
            services.AddRegisterIncidentReportCoreServices();
            return services;
        }
    }
}
