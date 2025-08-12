using ISO9001.GetAllIncidentReports.BusinessObjects.Interfaces;
using ISO9001.GetIncidentReportById.BusinessObjects.Interfaces;
using ISO9001.IncidentReports.Repositories.AuditEventProvider;
using ISO9001.Interfaces.Interfaces;
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
            services.AddScoped<IGetIncidentReportByIdRepository, GetIncidentReportByIdRepository>();

            services.AddScoped<IAuditEventProvider, IncidentReportEventProvider>();
            return services;
        }
    }
}
