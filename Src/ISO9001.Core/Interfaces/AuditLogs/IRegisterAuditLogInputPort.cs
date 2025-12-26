namespace ISO9001.Core.Interfaces.AuditLogs;

public interface IRegisterAuditLogInputPort
{
    Task HandleAsync(AuditLogDto auditLog);
}
