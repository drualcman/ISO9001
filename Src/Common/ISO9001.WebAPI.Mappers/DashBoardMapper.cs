namespace ISO9001.WebAPI.Mappers;

public static class DashBoardMapper
{
    public static IEndpointRouteBuilder MapQualityDashboardEndpoints(
        this IEndpointRouteBuilder builder)
    {
        builder.MapGet("{companyId}/dashboard/".CreateEndpoint("DashBoardEndpoints"), async (
            string companyId,
            [FromQuery] DateTime? from,
            [FromQuery] DateTime? end,
            IGetQualityDashBoardInputPort inputPort) =>
        {
            var result = await inputPort.HandleAsync(companyId, from, end);
            return TypedResults.Ok(result);
        });


        return builder;
    }
}
