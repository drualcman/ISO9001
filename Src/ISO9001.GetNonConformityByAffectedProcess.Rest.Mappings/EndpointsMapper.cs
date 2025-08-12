using ISO9001.GetNonConformityByAffectedProcess.BusinessObjects;
using ISO9001.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace ISO9001.GetNonConformityByAffectedProcess.Rest.Mappings
{
    public static class EndpointsMapper
    {
        public static IEndpointRouteBuilder MapGetNonConformityByAffectedProcessEndpoint(
            this IEndpointRouteBuilder builder)
        {

            builder.MapGet(("{companyId}/" + GetNonConformityByAffectedProcessEndpoint.AffectedProcess + "/{affectedProcess}").CreateEndpoint("NonConformityEndpoints"), async (
                string companyId,
                string affectedProcess,
                [FromQuery] DateTime? from,
                [FromQuery] DateTime? end,
                IGetNonConformityByAffectedProcessInputPort inputPort) =>
            {
                var result = await inputPort.HandleAsync(companyId, affectedProcess, from, end);
                return TypedResults.Ok(result);

            });


            return builder;
        }
    }

}
