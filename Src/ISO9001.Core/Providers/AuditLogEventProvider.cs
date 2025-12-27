namespace ISO9001.Core.Providers;

internal class AuditLogEventProvider(IQueryableAuditLogDataContext context) : IAuditEventProvider
{
    public string EventType => "AuditLog";

    public async Task<IEnumerable<AuditEventResponse>> GetAuditEventsAsync(string entityId, string companyId)
    {
        var data = await context.ToListAsync(AuditLog => AuditLog.EntityId == entityId &&
            AuditLog.CompanyId == companyId,
            AuditLog => AuditLog.OrderBy(AuditLog => AuditLog.LogId));
        return data.Select(AuditLog => new AuditEventResponse(
                AuditLog.LogId.ToString(),
                AuditLog.EntityId,
                AuditLog.Timestamp,
                EventType,
                AuditLog.Details,
                AuditLog.PerformedBy));
    }
}
