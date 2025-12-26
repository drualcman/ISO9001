using ISO9001.Core.Responses;

namespace ISO9001.Core.Features.Interfaces;

public interface IQueryableAuditEventRepository
{
    Task<IEnumerable<AuditEventResponse>> GetAuditEventsAsync(string entityId, string companyId);

}
