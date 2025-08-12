using ISO9001.GetAuditEvents.BusinessObjects.Interfaces;
using ISO9001.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace ISO9001.GetAuditEvents.Rest.Mappings
{
    public static class EndpointsMapper
    {
        public static IEndpointRouteBuilder MapGetAuditEventsEndpoint(
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
}
