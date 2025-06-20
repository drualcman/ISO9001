using ISO9001.Entities.Responses;

namespace GOGO.ISO9001.GetAuditLogsByAction.BusinessObjects.Interfaces
{
    public interface IGetAuditLogsByActionRepository
    {
        Task<IEnumerable<AuditLogResponse>> GetAuditLogsByActionAsync(string id, string action, DateTime? from, DateTime? end);
    }
}
