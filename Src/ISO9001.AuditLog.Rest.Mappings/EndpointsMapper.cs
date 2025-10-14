﻿namespace ISO9001.AuditLog.Rest.Mappings
{
    public static class EndpointsMapper
    {
        public static IEndpointRouteBuilder MapAuditLogEndpoints(
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

            builder.MapGet(("{companyId}/" + "Entity" + "/{entityId}").CreateEndpoint("AuditLogEndpoints"), async (
            string companyId,
            string entityId,
            [FromQuery] DateTime? from,
            [FromQuery] DateTime? end,
            IGetAuditLogsByEntityIdInputPort inputPort) =>
            {
                var result = await inputPort.HandleAsync(companyId, entityId, from, end);
                return TypedResults.Ok(result);

            });

            builder.MapGet(("{companyId}/" + "Action" + "/{action}").CreateEndpoint("AuditLogEndpoints"), async (
            string companyId,
            string action,
            [FromQuery] DateTime? from,
            [FromQuery] DateTime? end,
            IGetAuditLogsByActionInputPort inputPort) =>
            {
                var result = await inputPort.HandleAsync(companyId, action, from, end);
                return TypedResults.Ok(result);

            });

            builder.MapGet(("{companyId}/" + "Id" + "/{id}").CreateEndpoint("AuditLogEndpoints"), async (
             string companyId,
             int id,
             IGetAuditLogByIdInputPort inputport) =>
            {
                var Result = await inputport.HandleAsync(companyId, id);
                return TypedResults.Ok(Result);
            });

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
