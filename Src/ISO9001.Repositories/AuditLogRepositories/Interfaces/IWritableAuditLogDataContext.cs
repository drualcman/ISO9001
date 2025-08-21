using ISO9001.Repositories.AuditLogRepositories.Entities;

namespace ISO9001.Repositories.AuditLogRepositories.Interfaces
{
    public interface IWritableAuditLogDataContext
    {
        Task AddAsync(AuditLog auditLog);
        Task SaveChangesAsync();
    }
}

