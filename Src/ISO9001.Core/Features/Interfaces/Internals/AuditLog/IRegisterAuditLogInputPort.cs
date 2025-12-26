using ISO9001.Core.Dtos;

namespace ISO9001.Core.Features.Interfaces.Internals.AuditLog
{
    public interface IRegisterAuditLogInputPort
    {
        Task HandleAsync(AuditLogDto auditLog);
    }
}
