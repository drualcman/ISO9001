namespace ISO9001.Core.Interfaces.AuditEvents;

public interface IGetAuditEventInputPort
{
    Task<IEnumerable<AuditEventResponse>> HandleAsync(string entityId, string companyId);

}
