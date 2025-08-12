using ISO9001.GetIncidentReportById.BusinessObjects.Interfaces;
using ISO9001.GetIncidentReportById.Core.Handler;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.GetIncidentReportById.Core
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddGetIncidentReportByIdCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IGetIncidentReportByIdInputPort, GetIncidentReportByIdHandler>();

            return services;
        }
    }

}
