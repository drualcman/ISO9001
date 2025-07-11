using ISO9001.GetAllIncidentReports.BusinessObjects.Interfaces;
using ISO9001.GetAllIncidentReports.Core.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.GetAllIncidentReports.Core
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddGetAllIncidentReportsCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IGetAllIncidentReportsInputPort, GetAllIncidentReportsHandler>();
            return services;
        }
    }
}
