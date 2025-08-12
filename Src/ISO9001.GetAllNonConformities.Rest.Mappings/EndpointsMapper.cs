using ISO9001.GetAllNonConformities.BusinessObjects;
using ISO9001.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace ISO9001.GetAllNonConformities.Rest.Mappings
{
    public static class EndpointsMapper
    {
        public static IEndpointRouteBuilder MapGetAllNonConformitiesEndpoint(
            this IEndpointRouteBuilder builder)
        {
            builder.MapGet("{companyId}/".CreateEndpoint("NonConformityEndpoints"), async (
                string companyId,
                [FromQuery] DateTime? from,
                [FromQuery] DateTime? end,
                IGetAllNonConformitiesInputPort inputPort) =>
            {
                var result = await inputPort.HandleAsync(companyId, from, end);
                return TypedResults.Ok(result);
            });
            return builder;
        }
    }

}
