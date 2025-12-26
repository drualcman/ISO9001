namespace ISO9001.Core.Interfaces.Internals;

internal interface ICommandAuditLogRepository
{
    Task RegisterAuditLogAsync(AuditLogDto auditLog);
    Task SaveChangesAsync();
}
