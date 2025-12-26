namespace ISO9001.WebAPI.Mappers;

public static class AuditEventMapper
{
    public static IEndpointRouteBuilder MapAuditEventEndpoints(
        this IEndpointRouteBuilder builder)
    {
        builder.MapGet("{companyId}/".CreateEndpoint("AuditEventEndpoints"), async (
            string companyId,
            [FromQuery] string entityId,
            IGetAuditEventsInputPort inputPort) =>
        {
            var result = await inputPort.HandleAsync(entityId, companyId);
            return TypedResults.Ok(result);
        });

        return builder;
    }
}
