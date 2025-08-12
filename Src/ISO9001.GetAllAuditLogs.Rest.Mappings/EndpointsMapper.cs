using ISO9001.GetAllAuditLogs.BusinessObjects.Interfaces;
using ISO9001.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace ISO9001.GetAllAuditLogs.Rest.Mappings
{
    public static class EndpointsMapper
    {
        public static IEndpointRouteBuilder MapGetAllAuditLogsEndpoint(
            this IEndpointRouteBuilder builder)
        {
            builder.MapGet("{companyId}/".CreateEndpoint("AuditLogEndpoints"), async (
                string companyId,
                [FromQuery] DateTime? from,
                [FromQuery] DateTime? end,
                IGetAllAuditLogsInputPort inputPort) =>
            {
                var result = await inputPort.HandleAsync(companyId, from, end);
                return TypedResults.Ok(result);

            });

            return builder;
        }
    }

}
