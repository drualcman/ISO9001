using ISO9001.RegisterIncidentReport.BusinessObjects.Interfaces;
using ISO9001.RegisterIncidentReport.Core.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.RegisterIncidentReport.Core
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRegisterIncidentReportCoreServices(
            this IServiceCollection services)
        {
            services.AddScoped<IRegisterIncidentReportInputPort, RegisterIncidentReportHandler>();
            return services;
        }
    }
}
