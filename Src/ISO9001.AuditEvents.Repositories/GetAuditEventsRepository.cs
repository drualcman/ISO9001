using ISO9001.Entities.Responses;
using ISO9001.GetAuditEvents.BusinessObjects.Interfaces;
using ISO9001.Interfaces.Interfaces;

namespace ISO9001.AuditEvents.Repositories
{
    internal class GetAuditEventsRepository(IEnumerable<IAuditEventProvider> providers) : IGetAuditEventsRepository
    {
        public async Task<IEnumerable<AuditEventResponse>> GetAuditEventsAsync(string entityId,string companyId)
        {
            List<AuditEventResponse> AllAuditEvents = [];

            foreach(IAuditEventProvider provider in providers)
            {
                var AuditEvents = await provider.GetAuditEventsAsync(entityId, companyId);

                AllAuditEvents.AddRange(AuditEvents);
            }

            return AllAuditEvents;
        }
    }
}
