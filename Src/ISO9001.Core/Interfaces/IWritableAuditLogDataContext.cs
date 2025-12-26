namespace ISO9001.Core.Interfaces;

public interface IWritableAuditLogDataContext
{
    Task AddAsync(AuditLog auditLog);
    Task SaveChangesAsync();
}

