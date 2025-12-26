namespace ISO9001.Core.Features.AuditLog.Handlers;

internal class RegisterAuditLogHandler(ICommandAuditLogRepository repository) : IRegisterAuditLog
{
    public async Task HandleAsync(AuditLogDto auditLog)
    {
        await repository.RegisterAuditLogAsync(auditLog);
        await repository.SaveChangesAsync();
    }
}
