namespace ISO9001.Core.Interfaces.AuditLogs;

public interface IWritableAuditLogDataContext
{
    Task AddAsync(AuditLog auditLog);
    Task SaveChangesAsync();
}

