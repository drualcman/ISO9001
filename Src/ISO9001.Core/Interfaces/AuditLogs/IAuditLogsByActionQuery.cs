namespace ISO9001.Core.Interfaces.AuditLogs;

public interface IAuditLogsByActionQuery
{
    Task<IEnumerable<AuditLogResponse>> HandleAsync(string id, string action, DateTime? from, DateTime? end);
}
