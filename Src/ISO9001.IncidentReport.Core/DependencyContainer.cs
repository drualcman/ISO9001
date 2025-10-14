namespace ISO9001.IncidentReport.Core
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddIncidentReportCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IGetAllIncidentReportsInputPort, GetAllIncidentReportsHandler>();
            services.AddScoped<IGetIncidentReportByIdInputPort, GetIncidentReportByIdHandler>();
            services.AddScoped<IRegisterIncidentReportInputPort, RegisterIncidentReportHandler>();
            return services;
        }
    }

}
