namespace ISO9001.AuditEvent.Core.Handlers.GetAuditEvents
{
    internal class GetAuditEventsHandler(IQueryableAuditEventRepository repository) : IGetAuditEventsInputPort
    {
        public async Task<IEnumerable<AuditEventResponse>> HandleAsync(string entityId, string companyId)
        {

            return await repository.GetAuditEventsAsync(entityId, companyId);
        }
    }
}
