namespace ISO9001.IncidentReport.Core
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddIncidentReportCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IGetAllIncidentReportsInputPort, GetAllIncidentReportsHandler>();
            services.AddScoped<IGetIncidentReportByIdInputPort, GetIncidentReportByIdHandler>();
            services.AddScoped<IGetIncidentReportByEntityIdInputPort, GetIncidentReportByEntityIdHandler>();
            services.AddScoped<IRegisterIncidentReportInputPort, RegisterIncidentReportHandler>();

            services.AddScoped<IGenerateIncidentReportReportController, GenerateIncidentReportReportController>();
            services.AddScoped<IGenerateIncidentReportReportInputPort, GenerateIncidentReportReportHandler>();
            services.AddScoped<IGenerateIncidentReportReportOutputPort, GenerateIncidentReportReportPresenter>();
            return services;
        }
    }

}
