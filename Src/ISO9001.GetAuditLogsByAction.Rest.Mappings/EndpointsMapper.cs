using ISO9001.GetAuditLogsByAction.BusinessObjects.Interfaces;
using ISO9001.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace ISO9001.GetAuditLogsByAction.Rest.Mappings
{
    public static class EndpointsMapper
    {
        public static IEndpointRouteBuilder UseGetAuditLogByActionEndpoint(
            this IEndpointRouteBuilder builder)
        {
            builder.MapGet(("{companyId}/" + GetAuditLogsByActionEndpoint.Action + "/{action}").CreateEndpoint("AuditLogEndpoints"), async (
                string companyId,
                string action,
                [FromQuery] DateTime? from,
                [FromQuery] DateTime? end,
                IGetAuditLogsByActionInputPort inputPort) =>
            {
                var result = await inputPort.HandleAsync(companyId, action, from, end);
                return TypedResults.Ok(result);

            });

            return builder;
        }
    }

}
