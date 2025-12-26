namespace ISO9001.Core.Interfaces.AuditLogs;

public interface IRegisterAuditLog
{
    Task HandleAsync(AuditLogDto auditLog);
}
