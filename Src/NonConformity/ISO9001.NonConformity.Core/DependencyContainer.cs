using ISO9001.NonConformity.Core.Controllers.GenerateNonConformityDetailsReport;
using ISO9001.NonConformity.Core.Handlers.GenerateNonConformityDetailsReport;
using ISO9001.NonConformity.Core.Presenters.GenerateNonConformityDetailsReport;

namespace ISO9001.NonConformity.Core
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddNonConformityCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IGetAllNonConformitiesInputPort, GetAllNonConformitiesHandler>();
            services.AddScoped<IGetNonConformityByAffectedProcessInputPort, GetNonConformityByAffectedProcessHandler>();
            services.AddScoped<IGetNonConformityByEntityIdInputPort, GetNonConformityByEntityIdHandler>();
            services.AddScoped<IGetNonConformityByStatusInputPort, GetNonConformityByStatusHandler>();
            services.AddScoped<IRegisterNonConformityInputPort, RegisterNonConformityHandler>();
            services.AddScoped<IRegisterNonConformityDetailInputPort, RegisterNonConformityDetailHandler>();

            services.AddScoped<IGenerateNonConformityMasterReportController, GenerateNonConformityMasterReportController>();
            services.AddScoped<IGenerateNonConformityMasterReportInputPort, GenerateNonConformityMasterReportHandler>();
            services.AddScoped<IGenerateNonConformityMasterReportOutputPort, GenerateNonConformityMasterReportPresenter>();

            services.AddScoped<IGenerateNonConformityDetailsReportController, GenerateNonConformityDetailsReportController>();
            services.AddScoped<IGenerateNonConformityDetailsReportInputPort, GenerateNonConformityDetailsReportHandler>();
            services.AddScoped<IGenerateNonConformityDetailsReportOutputPort, GenerateNonConformityDetailsReportPresenter>();
            return services;
        }
    }

}
