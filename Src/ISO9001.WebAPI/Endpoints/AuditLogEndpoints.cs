using ISO9001.Entities.Dtos;
using ISO9001.Entities.Requests;
using ISO9001.GetAllAuditLogs.BusinessObjects;
using ISO9001.GetAuditLogsByAction.BusinessObjects.Interfaces;
using ISO9001.GetAuditLogsByAction.Rest;
using ISO9001.GetAuditLogsByEntityId.Rest;
using ISO9001.GetAuditLogsByEntityIdBusinessObjects.Interfaces;
using ISO9001.RegisterAuditLog.BusinessObjects.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ISO9001.WebAPI.Endpoints
{
    public static class AuditLogEndpoints
    {
        public static IEndpointRouteBuilder UserAuditLogEndpoints(this IEndpointRouteBuilder builder)
        {
            builder.MapPost("".CreateEndpoint(nameof(AuditLogEndpoints)),
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

            builder.MapGet("{id}/".CreateEndpoint(nameof(AuditLogEndpoints)), async (
                string id,
                [FromQuery] DateTime? from,
                [FromQuery] DateTime? end,
                IGetAllAuditLogsInputPort inputPort) =>
            {
                var result = await inputPort.HandleAsync(id, from, end);
                return TypedResults.Ok(result);

            });

            builder.MapGet(("{id}/" + GetAuditLogsByEntityIdEndpoint.Entity + "/{entityId}").CreateEndpoint(nameof(AuditLogEndpoints)), async (
                string id,
                string entityId,
                [FromQuery] DateTime? from,
                [FromQuery] DateTime? end,
                IGetAuditLogsByEntityIdInputPort inputPort) =>
            {
                var result = await inputPort.HandleAsync(id, entityId, from, end);
                return TypedResults.Ok(result);

            });

            builder.MapGet(("{id}/" + GetAuditLogsByActionEndpoint.Action + "/{action}").CreateEndpoint(nameof(AuditLogEndpoints)), async (
                string id,
                string action,
                [FromQuery] DateTime? from,
                [FromQuery] DateTime? end,
                IGetAuditLogsByActionInputPort inputPort) =>
            {
                var result = await inputPort.HandleAsync(id, action, from, end);
                return TypedResults.Ok(result);

            });

            return builder;
        }
    }
}
