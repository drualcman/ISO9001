using ISO9001.GetAllAuditLogs.Rest.Mappings;
using ISO9001.GetAllCustomerFeedback.Rest.Mappings;
using ISO9001.GetAllIncidentReports.Rest.Mappings;
using ISO9001.GetAllNonConformities.Rest.Mappings;
using ISO9001.GetAuditEvents.Rest.Mappings;
using ISO9001.GetAuditLogById.Rest.Mappings;
using ISO9001.GetAuditLogsByAction.Rest.Mappings;
using ISO9001.GetAuditLogsByEntityId.Rest.Mappings;
using ISO9001.GetCustomerFeedbackByCustomerId.Rest.Mappings;
using ISO9001.GetCustomerFeedbackByEntityId.Rest.Mappings;
using ISO9001.GetCustomerFeedbackById.Mappings;
using ISO9001.GetCustomerFeedbackByRating.Rest.Mappings;
using ISO9001.GetIncidentReportById.Mappings;
using ISO9001.GetNonConformityByAffectedProcess.Rest.Mappings;
using ISO9001.GetNonConformityByEntityId.Rest.Mappings;
using ISO9001.GetNonConformityByStatus.Rest.Mappings;
using ISO9001.RegisterAuditLog.Rest.Mappings;
using ISO9001.RegisterCustomerFeedback.Rest.Mappings;
using ISO9001.RegisterIncidentReport.Rest.Mappings;
using ISO9001.RegisterNonConformity.Rest.Mappings;
using ISO9001.RegisterNonConformityDetail.Rest.Mappings;

namespace ISO9001.WebAPI
{
    public static class EndpointsMapper
    {
        public static IEndpointRouteBuilder UseISO9001Endpoints(
            this IEndpointRouteBuilder builder)
        {
            builder.UseGetAllAuditLogsEndpoint();
            builder.UseGetAuditLogByIdEndpoint();
            builder.UseGetAuditLogByActionEndpoint();
            builder.UseGetAuditLogsByEntityIdEndpoint();
            builder.UseRegisterAuditLogEndpoint();

            builder.UseGetAllCustomerFeedbackEndpoints();
            builder.UseGetCustomerFeedbackByIdEndpoint();
            builder.UseGetCustomerFeedbackByRatingEndpoint();
            builder.UseGetCustomerFeedbackByCustomerIdEndpoint();
            builder.UseGetCustomerFeedbackByEntityIdEndpoint();
            builder.UseRegisterCustomerFeedbackEndpoint();

            builder.UseGetAllIncidentReportsEndpoint();
            builder.UseRegisterIncidentReportEndpoint();
            builder.UseGetIncidentReportByIdEndpoint();

            builder.UseGetAllNonConformitiesEndpoint();
            builder.UseGetNonConformityByAffectedProcessEndpoint();
            builder.UseGetNonConformityByEntityIdEndpoint();
            builder.UseGetNonConformityByStatusEndpoint();
            builder.UseRegisterNonConformityEndpoint();
            builder.UseRegisterNonConformityDetailEndpoint();

            builder.UseGetAuditEventsEndpoint();

            return builder;
        }
    }
}
