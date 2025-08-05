using ISO9001.Entities.Responses;

namespace ISO9001.Interfaces.Interfaces
{
    public interface IAuditEventProvider
    {
        string EventType { get; }
        Task<IEnumerable<AuditEventResponse>> GetAuditEventsAsync(string entityId, string companyId);
    }
}
