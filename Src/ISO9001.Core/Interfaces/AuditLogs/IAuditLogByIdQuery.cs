namespace ISO9001.Core.Interfaces.AuditLogs;

public interface IAuditLogByIdQuery
{
    Task<AuditLogResponse> HandleAsync(string companyId, int id);
}
