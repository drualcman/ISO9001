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

            builder.MapGetAllNonConformitiesEndpoint();
            builder.MapGetNonConformityByAffectedProcessEndpoint();
            builder.MapGetNonConformityByEntityIdEndpoint();
            builder.MapGetNonConformityByStatusEndpoint();
            builder.MapRegisterNonConformityEndpoint();
            builder.MapRegisterNonConformityDetailEndpoint();

            builder.MapGetAuditEventsEndpoint();
            builder.MapGetQualityDashBoard();

            return builder;
        }
    }
}
