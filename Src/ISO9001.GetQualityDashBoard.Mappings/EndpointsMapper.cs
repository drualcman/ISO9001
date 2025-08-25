using ISO9001.GetQualityDashBoard.BusinessObjects.Interfaces;
using ISO9001.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace ISO9001.GetQualityDashBoard.Mappings
{
    public static class EndpointsMapper
    {
        public static IEndpointRouteBuilder MapGetQualityDashBoard(
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

}
