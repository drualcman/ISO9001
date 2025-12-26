namespace ISO9001.Core.Features.AuditLog.Handlers;

internal class GetAuditLogsByActionHandler(IQueryableAuditLogRepository repository) : IAuditLogsByActionQuery
{
    public async Task<IEnumerable<AuditLogResponse>> HandleAsync(string id, string action, DateTime? from, DateTime? end)
    {
        DateTime UtcFrom = from != null ? from.Value.Date
            : DateTime.UtcNow.Date.AddDays(-30);

        DateTime UtcEnd = end != null ? end.Value.Date.AddDays(1).AddTicks(-1)
            : DateTime.UtcNow.Date.AddDays(1).AddTicks(-1);

        return await repository.GetAuditLogsByActionAsync(id, action, UtcFrom, UtcEnd);
    }
}
