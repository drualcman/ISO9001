using ISO9001.Entities.Responses;

namespace ISO9001.GetAllAuditLogs.BusinessObjects.Interfaces
{
    public interface IGetAllAuditLogsInputPort
    {
        Task<IEnumerable<AuditLogResponse>> HandleAsync(string id, DateTime? from, DateTime? end);
    }
}
