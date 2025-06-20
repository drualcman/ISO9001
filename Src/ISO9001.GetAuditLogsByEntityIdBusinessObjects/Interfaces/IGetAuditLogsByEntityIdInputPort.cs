using ISO9001.Entities.Responses;

namespace ISO9001.GetAuditLogsByEntityIdBusinessObjects.Interfaces
{
    public interface IGetAuditLogsByEntityIdInputPort
    {
        Task<IEnumerable<AuditLogResponse>> HandleAsync(string id, string entityId, DateTime? from, DateTime? end);
    }
}
