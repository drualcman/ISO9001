namespace ISO9001.Core.Interfaces.AuditEvents;

public interface IAuditEventQuery
{
    Task<IEnumerable<AuditEventResponse>> HandleAsync(string entityId, string companyId);

}
