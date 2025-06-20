using ISO9001.AuditLogs.Repositories.Entities;

namespace ISO9001.AuditLogs.Repositories.Interfaces
{
    public interface IRegisterAuditLogDataContext
    {
        Task AddAsync(AuditLog auditLog);
        Task SaveChangesAsync();
    }
}
