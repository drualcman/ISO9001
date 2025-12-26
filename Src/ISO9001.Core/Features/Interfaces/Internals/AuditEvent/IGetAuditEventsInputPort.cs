using ISO9001.Core.Responses;

namespace ISO9001.Core.Features.Interfaces.Internals.AuditEvent;

public interface IGetAuditEventsInputPort
{
    Task<IEnumerable<AuditEventResponse>> HandleAsync(string entityId, string companyId);

}
