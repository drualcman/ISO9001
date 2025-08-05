using ISO9001.Entities.Responses;
using ISO9001.GetAuditEvents.BusinessObjects.Interfaces;

namespace ISO9001.GetAuditEvents.Core.Handlers
{
    internal class GetAuditEventsHandler(IGetAuditEventsRepository repository) : IGetAuditEventsInputPort
    {
        public async Task<IEnumerable<AuditEventResponse>> HandleAsync(string entityId, string companyId)
        {

            return await repository.GetAuditEventsAsync(entityId, companyId);
        }
    }
}
