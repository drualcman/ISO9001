namespace ISO9001.Repositories.AuditEvent
{
    internal class QueryableAuditEventRepository(IEnumerable<IAuditEventProvider> providers) : IQueryableAuditEventRepository
    {
        public async Task<IEnumerable<AuditEventResponse>> GetAuditEventsAsync(string entityId, string companyId)
        {
            List<AuditEventResponse> AllAuditEvents = [];

            foreach (IAuditEventProvider provider in providers)
            {
                var AuditEvents = await provider.GetAuditEventsAsync(entityId, companyId);

                AllAuditEvents.AddRange(AuditEvents);
            }

            return AllAuditEvents;

        }
    }
}