using ISO9001.Entities.Responses;

namespace ISO9001.GetAuditEvents.BusinessObjects.Interfaces
{
    public interface IGetAuditEventsRepository
    {
        Task<IEnumerable<AuditEventResponse>> GetAuditEventsAsync(string entityId, string companyId);
    }
}
