using ISO9001.Entities.Responses;

namespace GOGO.ISO9001.GetAuditLogsByAction.BusinessObjects.Interfaces
{
    public interface IGetAuditLogsByActionInputPort
    {
        Task<IEnumerable<AuditLogResponse>> HandleAsync(string id, string action, DateTime? from, DateTime? end);
    }
}
