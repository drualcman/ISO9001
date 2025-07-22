using ISO9001.GetAuditLogsByEntityIdBusinessObjects.Interfaces;
using ISO9001.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace ISO9001.GetAuditLogsByEntityId.Rest.Mappings
{
    public static class EndpointsMapper
    {
        public static IEndpointRouteBuilder UseGetAuditLogsByEntityIdEndpoint(
            this IEndpointRouteBuilder builder)
        {
            builder.MapGet(("{companyId}/" + GetAuditLogsByEntityIdEndpoint.Entity + "/{entityId}").CreateEndpoint("AuditLogEndpoints"), async (
                string companyId,
                string entityId,
                [FromQuery] DateTime? from,
                [FromQuery] DateTime? end,
                IGetAuditLogsByEntityIdInputPort inputPort) =>
            {
                var result = await inputPort.HandleAsync(companyId, entityId, from, end);
                return TypedResults.Ok(result);

            });
            return builder;
        }
    }

}
