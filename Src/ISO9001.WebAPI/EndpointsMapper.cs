using ISO9001.NonConformity.Rest.Mappings;

namespace ISO9001.WebAPI
{
    public static class EndpointsMapper
    {
        public static IEndpointRouteBuilder MapISO9001Endpoints(
            this IEndpointRouteBuilder builder)
        {
            builder.MapAuditLogEndpoints();
            builder.MapCustomerFeedbackEndpoints();
            builder.MapIncidentReportEndpoints();
            builder.MapNonConformityEndpoints();


            builder.MapGetAuditEventsEndpoint();
            builder.MapGetQualityDashBoard();

            return builder;
        }
    }
}
