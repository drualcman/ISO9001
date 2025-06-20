using ISO9001.RegisterIncidentReport.BusinessObjects.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.RegisterIncidentReport.Repositories
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRegisterIncidentReportRepositoryService(
            this IServiceCollection services)
        {
            services.AddScoped<IRegisterIncidentReportRepository, RegisterIncidentReportRepository>();
            return services;
        }
    }
}
