using ISO9001.GetNonConformityByStatus.BusinessObjects;
using ISO9001.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace ISO9001.GetNonConformityByStatus.Rest.Mappings
{
    public static class EndpointsMapper
    {
        public static IEndpointRouteBuilder UseGetNonConformityByStatusEndpoint(
            this IEndpointRouteBuilder builder)
        {
            builder.MapGet(("{companyId}/" + GetNonConformityByStatusEndpoint.Status + "/{status}").CreateEndpoint("NonConformityEndpoints"), async (
                string companyId,
                string status,
                [FromQuery] DateTime? from,
                [FromQuery] DateTime? end,
                IGetNonConformityByStatusInputPort inputPort) =>
            {
                var result = await inputPort.HandleAsync(companyId, status, from, end);
                return TypedResults.Ok(result);

            });

            return builder;
        }
    }

}
