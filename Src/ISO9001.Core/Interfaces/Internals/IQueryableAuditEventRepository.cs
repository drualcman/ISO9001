namespace ISO9001.Core.Interfaces.Internals;

internal interface IQueryableAuditEventRepository
{
    Task<IEnumerable<AuditEventResponse>> GetAuditEventsAsync(string entityId, string companyId);

}
