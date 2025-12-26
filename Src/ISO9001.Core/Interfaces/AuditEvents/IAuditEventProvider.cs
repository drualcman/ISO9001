namespace ISO9001.Core.Interfaces.AuditEvents;

public interface IAuditEventProvider
{
    string EventType { get; }
    Task<IEnumerable<AuditEventResponse>> GetAuditEventsAsync(string entityId, string companyId);
}
