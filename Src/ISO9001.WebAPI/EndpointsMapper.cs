namespace ISO9001.WebAPI;

public static class EndpointsMapper
{
    public static IEndpointRouteBuilder MapISO9001Endpoints(
        this IEndpointRouteBuilder builder)
    {
        builder.MapAuditLogEndpoints();
        builder.MapCustomerFeedbackEndpoints();
        builder.MapIncidentReportEndpoints();
        builder.MapNonConformityEndpoints();


        builder.MapAuditEventEndpoints();
        builder.MapQualityDashboardEndpoints();
        builder.MapAuditReportEndpoints();
        return builder;
    }
}
