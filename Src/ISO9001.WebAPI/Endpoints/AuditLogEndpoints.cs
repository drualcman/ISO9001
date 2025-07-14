using ISO9001.Entities.Dtos;
using ISO9001.Entities.Requests;
using ISO9001.GetAllAuditLogs.BusinessObjects;
using ISO9001.GetAllAuditLogs.Rest;
using ISO9001.GetAuditLogsByAction.BusinessObjects.Interfaces;
using ISO9001.GetAuditLogsByAction.Rest;
using ISO9001.GetAuditLogsByEntityId.Rest;
using ISO9001.GetAuditLogsByEntityIdBusinessObjects.Interfaces;
using ISO9001.RegisterAuditLog.BusinessObjects.Interfaces;
using ISO9001.RegisterAuditLog.Rest;
using Microsoft.AspNetCore.Mvc;

namespace ISO9001.WebAPI.Endpoints
{
    public static class AuditLogEndpoints
    {
        const string EntryPoint = "audit-log/";

        public static IEndpointRouteBuilder UserAuditLogEndpoints(this IEndpointRouteBuilder builder)
        {
            builder.MapPost(RegisterAuditLogEndpoint.RegisterAuditLog.CreateEndpoint(EntryPoint),
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

            builder.MapGet(("{id}/" + GetAllAuditLogsEndpoint.GetAllAuditLogs).CreateEndpoint(EntryPoint), async (
                string id,
                [FromQuery] DateTime? from,
                [FromQuery] DateTime? end,
                IGetAllAuditLogsInputPort inputPort) =>
            {
                var result = await inputPort.HandleAsync(id, from, end);
                return TypedResults.Ok(result);

            });

            builder.MapGet(("{id}/" + GetAuditLogsByEntityIdEndpoint.GetAuditLogsByEntityId + "/{entityId}").CreateEndpoint(EntryPoint), async (
                string id,
                string entityId,
                [FromQuery] DateTime? from,
                [FromQuery] DateTime? end,
                IGetAuditLogsByEntityIdInputPort inputPort) =>
            {
                var result = await inputPort.HandleAsync(id, entityId, from, end);
                return TypedResults.Ok(result);

            });

            builder.MapGet(("{id}/" + GetAuditLogsByActionEndpoint.GetAuditLogsByAction + "/{action}").CreateEndpoint(EntryPoint), async (
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
