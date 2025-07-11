using ISO9001.GetAllIncidentReports.Core;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.GetAllIncidentReports.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddGetAllIncidentReportServices(this IServiceCollection services)
        {
            services.AddGetAllIncidentReportsCoreServices();

            return services;
        }
    }

}
