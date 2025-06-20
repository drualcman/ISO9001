using ISO9001.Entities.Responses;

namespace ISO9001.GetAuditLogsByEntityIdBusinessObjects.Interfaces
{
    public interface IGetAuditLogsByEntityIdRepository
    {
        Task<IEnumerable<AuditLogResponse>> GetAuditLogsByEntityIdAsync(string id, string entityId, DateTime? from, DateTime? end);
    }
}
