using ISO9001.Core.Responses;

namespace ISO9001.Core.Features.AuditEvent.Handlers;

internal class GetAuditEventsHandler(IQueryableAuditEventRepository repository) : IGetAuditEventsInputPort
{
    public async Task<IEnumerable<AuditEventResponse>> HandleAsync(string entityId, string companyId)
    {

        return await repository.GetAuditEventsAsync(entityId, companyId);
    }
}
