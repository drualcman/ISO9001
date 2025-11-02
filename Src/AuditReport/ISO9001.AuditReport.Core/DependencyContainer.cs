namespace ISO9001.AuditReport.Core
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddAuditReportCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IGenerateAuditReportController, GenerateAuditReportController>();
            services.AddScoped<IGenerateAuditReportInputPort, GenerateAuditReportHandler>();
            services.AddScoped<IGenerateAuditReportOutputPort, GenerateAuditReportPresenter>();

            return services;
        }
    }

}
