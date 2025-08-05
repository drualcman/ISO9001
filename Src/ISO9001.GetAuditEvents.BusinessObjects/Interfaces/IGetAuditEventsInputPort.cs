using ISO9001.Entities.Responses;

namespace ISO9001.GetAuditEvents.BusinessObjects.Interfaces
{
    public interface IGetAuditEventsInputPort
    {
        Task<IEnumerable<AuditEventResponse>> HandleAsync(string entityId, string companyId);
    }
}
