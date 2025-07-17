using ISO9001.AuditLogs.Repositories.Entities;

namespace ISO9001.AuditLogs.Repositories.Interfaces
{
    public interface IWritableAuditLogDataContext
    {
        Task AddAsync(AuditLog auditLog);
        Task SaveChangesAsync();
    }
}

