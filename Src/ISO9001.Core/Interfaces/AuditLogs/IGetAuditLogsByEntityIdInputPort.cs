namespace ISO9001.Core.Interfaces.AuditLogs;

public interface IGetAuditLogsByEntityIdInputPort
{
    Task<IEnumerable<AuditLogResponse>> HandleAsync(string id, string entityId, DateTime? from, DateTime? end);
}
