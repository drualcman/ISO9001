using ISO9001.AuditLogs.Repositories;
using ISO9001.CustomerFeedbacks.Repositories;
using ISO9001.Database.InMemory;
using ISO9001.GetAllAuditLogs.IoC;
using ISO9001.GetAllCustomerFeedback.IoC;
using ISO9001.GetAllNonConformities.IoC;
using ISO9001.GetAuditLogsByAction.IoC;
using ISO9001.GetAuditLogsByEntityId.IoC;
using ISO9001.GetCustomerFeedbackByCustomerId.IoC;
using ISO9001.GetCustomerFeedbackByEntityId.IoC;
using ISO9001.GetCustomerFeedbackByRating.IoC;
using ISO9001.GetNonConformityByAffectedProcess.IoC;
using ISO9001.GetNonConformityByEntityId.IoC;
using ISO9001.GetNonConformityByStatus.IoC;
using ISO9001.NonConformities.Repositories;
using ISO9001.RegisterAuditLog.IoC;
using ISO9001.RegisterCustomerFeedback.IoC;
using ISO9001.RegisterIncidentReportIoC;
using ISO9001.RegisterNonConformityDetail.IoC;
using ISO9001.RegisterNonConformityIoC;

namespace ISO9001.WebAPI
{
    public static class Services
    {
        public static WebApplicationBuilder AddISO9001Services(this WebApplicationBuilder builder)
        {
            builder.Services.AddGetAllAuditLogsServices();
            builder.Services.AddGetAuditLogsByEntityIdServices();
            builder.Services.AddGetAuditLogsByActionServices();
            builder.Services.AddRegisterAuditLogServices();
            builder.Services.AddAuditLogsRepositoryServices();

            builder.Services.AddRegisterCustomerFeedbackServices();
            builder.Services.AddGetAllCustomerFeedbackServices();
            builder.Services.AddGetCustomerFeedbackByEntityIdServices();
            builder.Services.AddGetCustomerFeedbackByCustomerIdServices();
            builder.Services.AddGetCustomerFeedbackByRatingServices();
            builder.Services.AddCustomerFeedbacksRepositoryServices();

            builder.Services.AddRegisterIncidentReportServices();

            builder.Services.AddRegisterNonConformityServices();
            builder.Services.AddRegisterNonConformityDetailServices();
            builder.Services.AddGetAllNonConformitiesServices();
            builder.Services.AddGetNonConformityByAffectedProcessServices();
            builder.Services.AddGetNonConformityByEntityIdServices();
            builder.Services.AddGetNonConformityByStatusServices();
            builder.Services.AddNonConformityRepositoryServices();

            builder.Services.AddDatabaseInMemory();

            builder.Services.AddWebApiDocumentator(options =>
            {
                options.ApiName = "GOGO.ISO9001";
                options.Version = "v1";
                options.Description = "Implementación de ISO 9001";
                options.DocsBaseUrl = "docs/api";
            });

            return builder;
        }
    }
}
