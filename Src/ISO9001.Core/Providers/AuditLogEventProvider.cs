using ISO9001.Core.Interfaces;

namespace ISO9001.Core.Providers;

internal class AuditLogEventProvider(IQueryableAuditLogDataContext context) : IAuditEventProvider
{
    public string EventType => "AuditLog";

    public async Task<IEnumerable<AuditEventResponse>> GetAuditEventsAsync(string entityId, string companyId)
    {
        var AuditLogs = context.AuditLogs.Where
            (AuditLog => AuditLog.EntityId == entityId &&
            AuditLog.CompanyId == companyId)
            .OrderBy(AuditLog => AuditLog.LogId)
            .Select(AuditLog => new AuditEventResponse(
                AuditLog.LogId.ToString(),
                AuditLog.EntityId,
                AuditLog.Timestamp,
                EventType,
                AuditLog.Details,
                AuditLog.PerformedBy));

        return await Task.FromResult(AuditLogs);
    }
}
