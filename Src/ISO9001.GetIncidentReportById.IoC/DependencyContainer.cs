using ISO9001.GetIncidentReportById.Core;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.GetIncidentReportById.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddGetIncidentReportByIdServices(this IServiceCollection services)
        {
            services.AddGetIncidentReportByIdCoreServices();
            return services;
        }
    }

}
