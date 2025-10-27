namespace ISO9001.AuditReport.Rest.Mappings
{
    public static class EndpointsMapper
    {
        public static IEndpointRouteBuilder MapAuditReportEndpoints(
            this IEndpointRouteBuilder builder)
        {
            builder.MapGet(
                "{companyId}/{entityId}/"
                .CreateEndpoint("AuditReportEndpoints"),
                 async (
                string companyId,
                string entityId,
                [FromQuery] DateTime? from,
                [FromQuery] DateTime? end,
                IGenerateAuditReportController controller) =>
                 {
                    byte[] Bytes = await controller.HandleAsync(companyId, entityId, from, end);
                     return Results.File(Bytes, "application/pdf", "AuditReport.pdf");
                 });
            return builder;
        }
    }

}
