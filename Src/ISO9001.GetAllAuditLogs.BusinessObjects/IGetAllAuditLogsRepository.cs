using ISO9001.Entities.Responses;

namespace ISO9001.GetAllAuditLogs.BusinessObjects
{
    public interface IGetAllAuditLogsRepository
    {
        Task<IEnumerable<AuditLogResponse>> GetAllAuditLogsOrderedByIdAscendingAsync(string id, DateTime? from, DateTime? end);
    }
}
