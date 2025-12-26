using ISO9001.Core.Dtos;

namespace ISO9001.Core.Features.Interfaces;

public interface ICommandAuditLogRepository
{
    Task RegisterAuditLogAsync(AuditLogDto auditLog);
    Task SaveChangesAsync();
}
