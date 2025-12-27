namespace ISO9001.Core.Repositories.AuditLogRepositories;

internal class QueryableAuditLogRepository(IQueryableAuditLogDataContext dataContext) : IQueryableAuditLogRepository
{
    public async Task<IEnumerable<AuditLogResponse>> GetAuditLogsByEntityIdAsync(string id, string entityId,
    DateTime? from, DateTime? end)
    {
        var AuditLogs = await dataContext.ToListAsync(
            AuditLog => AuditLog.CompanyId == id &&
                        AuditLog.EntityId == entityId &&
                            AuditLog.Timestamp >= from &&
                            AuditLog.Timestamp <= end);

        return AuditLogs.Select(AuditLog => new AuditLogResponse(
            AuditLog.LogId,
            AuditLog.EntityId,
            AuditLog.Action,
            AuditLog.PerformedBy,
            AuditLog.Timestamp,
            AuditLog.CreatedAt,
            AuditLog.Details));
    }

    public async Task<IEnumerable<AuditLogResponse>> GetAuditLogsByActionAsync(string id, string action,
    DateTime? from, DateTime? end)
    {
        var AuditLogs = await dataContext.ToListAsync(
            AuditLog => AuditLog.CompanyId == id &&
                            AuditLog.Action == action &&
                            AuditLog.Timestamp >= from &&
                            AuditLog.Timestamp <= end);

        return AuditLogs.Select(AuditLog => new AuditLogResponse(
            AuditLog.LogId,
            AuditLog.EntityId,
            AuditLog.Action,
            AuditLog.PerformedBy,
            AuditLog.Timestamp,
            AuditLog.CreatedAt,
            AuditLog.Details));
    }

    public async Task<bool> AuditLogExitsByIdAsync(string companyId, int id)
    {
        var AuditLog = await dataContext.ToListAsync(AuditLog => AuditLog.CompanyId == companyId &&
                AuditLog.LogId == id);

        return AuditLog.Any();
    }

    public async Task<AuditLogResponse> GetAuditLogByIdAsync(string companyId, int id)
    {
        var data = await dataContext.
            ToListAsync(
            AuditLog => AuditLog.CompanyId == companyId &&
                AuditLog.LogId == id);
        var AuditLog = data.FirstOrDefault();

        return new AuditLogResponse(
            AuditLog.LogId,
            AuditLog.EntityId,
            AuditLog.Action,
            AuditLog.PerformedBy,
            AuditLog.Timestamp,
            AuditLog.CreatedAt,
            AuditLog.Details);
    }

    public async Task<IEnumerable<AuditLogResponse>> GetAllAuditLogsOrderedByIdAscendingAsync(
    string id, DateTime? from, DateTime? end)
    {
        var AuditLogs = await dataContext.ToListAsync(
            AuditLog => AuditLog.CompanyId == id &&
                            AuditLog.Timestamp >= from &&
                            AuditLog.Timestamp <= end,
            o => o.OrderBy(a => a.LogId));

        return AuditLogs.Select(AuditLog => new AuditLogResponse(
            AuditLog.LogId,
            AuditLog.EntityId,
            AuditLog.Action,
            AuditLog.PerformedBy,
            AuditLog.Timestamp,
            AuditLog.CreatedAt,
            AuditLog.Details));
    }
}
