namespace ISO9001.AuditEvent.Core.Interfaces
{
    public interface IQueryableAuditEventRepository
    {
        Task<IEnumerable<AuditEventResponse>> GetAuditEventsAsync(string entityId, string companyId);

    }
}
