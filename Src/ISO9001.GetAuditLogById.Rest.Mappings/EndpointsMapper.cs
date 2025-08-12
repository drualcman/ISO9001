using ISO9001.GetAuditLogById.BusinessObjects.Interfaces;
using ISO9001.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace ISO9001.GetAuditLogById.Rest.Mappings
{
    public static class EndpointsMapper
    {
        public static IEndpointRouteBuilder UseGetAuditLogByIdEndpoint(
            this IEndpointRouteBuilder builder)
        {
            builder.MapGet(("{companyId}/" + GetAuditLogByIdEndpoint.Id + "/{id}").CreateEndpoint("AuditLogEndpoints"), async (
                string companyId,
                int id,
                IGetAuditLogByIdInputPort inputport) =>
            {
                var Result = await inputport.HandleAsync(companyId, id);
                return TypedResults.Ok(Result);
            }
            );
            return builder;
        }
    }

}
