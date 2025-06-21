using ISO9001.Entities.Dtos;

namespace ISO9001.RegisterAuditLog.BusinessObjects.Interfaces
{
    public interface IRegisterAuditLogInputPort
    {
        Task HandleAsync(AuditLogDto auditLog);
    }
}
