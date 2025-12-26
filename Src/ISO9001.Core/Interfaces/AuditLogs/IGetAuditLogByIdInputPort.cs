namespace ISO9001.Core.Interfaces.AuditLogs;

public interface IGetAuditLogByIdInputPort
{
    Task<AuditLogResponse> HandleAsync(string companyId, int id);
}
