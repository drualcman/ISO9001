using ISO9001.Entities.Dtos;

namespace ISO9001.RegisterAuditLog.BusinessObjects.Interfaces
{
    public interface IRegisterAuditLogRepository
    {
        Task RegisterAuditLogAsync(AuditLogDto auditLog);
        Task SaveChangesAsync();
    }
}
