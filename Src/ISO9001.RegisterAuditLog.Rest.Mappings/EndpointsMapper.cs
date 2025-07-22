using ISO9001.Entities.Dtos;
using ISO9001.Entities.Requests;
using ISO9001.Helpers;
using ISO9001.RegisterAuditLog.BusinessObjects.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace ISO9001.RegisterAuditLog.Rest.Mappings
{
    public static class EndpointsMapper
    {
        public static IEndpointRouteBuilder UseRegisterAuditLogEndpoint(
            this IEndpointRouteBuilder builder)
        {
            builder.MapPost("".CreateEndpoint("AuditLogEndpoints"),
                async (AuditLogRequest auditLog, IRegisterAuditLogInputPort inputPort) =>
                {
                    await inputPort.HandleAsync(new AuditLogDto(
                        auditLog.EntityId,
                        auditLog.CompanyId,
                        auditLog.Action,
                        auditLog.PerformedBy,
                        auditLog.Timestamp,
                        auditLog.Details,
                        auditLog.Data)
                        );
                    return TypedResults.Created();
                });

            return builder;
        }
    }

}
