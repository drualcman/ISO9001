using ISO9001.GetAllIncidentReports.BusinessObjects.Interfaces;
using ISO9001.RegisterIncidentReport.BusinessObjects.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.IncidentReports.Repositories
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddIncidentReportRepositoryServices(
            this IServiceCollection services)
        {
            services.AddScoped<IRegisterIncidentReportRepository, RegisterIncidentReportRepository>();
            services.AddScoped<IGetAllIncidentReportsRepository, GetAllIncidentReportsRepository>();
            return services;
        }
    }
}
