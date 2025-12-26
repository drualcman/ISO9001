using ISO9001.Core.Responses;

namespace ISO9001.Core.Features.Interfaces;

public interface IQueryableAuditLogRepository
{
    Task<IEnumerable<AuditLogResponse>> GetAllAuditLogsOrderedByIdAscendingAsync(string id, DateTime? from, DateTime? end);

    Task<AuditLogResponse> GetAuditLogByIdAsync(string companyId, int id);

    Task<bool> AuditLogExitsByIdAsync(string companyId, int id);

    Task<IEnumerable<AuditLogResponse>> GetAuditLogsByActionAsync(string id, string action, DateTime? from, DateTime? end);

    Task<IEnumerable<AuditLogResponse>> GetAuditLogsByEntityIdAsync(string id, string entityId, DateTime? from, DateTime? end);
}
