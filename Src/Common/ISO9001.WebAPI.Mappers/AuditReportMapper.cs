namespace ISO9001.WebAPI.Mappers;

public static class AuditReportMapper
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
            IGenerateAuditReport controller) =>
             {
                 return Results.Ok(await controller.HandleAsync(companyId, entityId, from, end));
             });
        return builder;
    }
}
