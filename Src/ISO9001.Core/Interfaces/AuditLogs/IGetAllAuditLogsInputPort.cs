namespace ISO9001.Core.Interfaces.AuditLogs;

public interface IGetAllAuditLogsInputPort
{
    Task<IEnumerable<AuditLogResponse>> HandleAsync(string id, DateTime? from, DateTime? end);
}
