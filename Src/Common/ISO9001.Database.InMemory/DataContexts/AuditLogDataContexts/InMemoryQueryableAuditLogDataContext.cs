namespace ISO9001.Database.InMemory.DataContexts.AuditLogDataContexts
{
    internal class InMemoryQueryableAuditLogDataContext(
        InMemoryAuditLogStore dataContext) : IQueryableAuditLogDataContext
    {
        public IQueryable<AuditLogReadModel> AuditLogs =>
            dataContext.AuditLogs
                .Select(AuditLog => new AuditLogReadModel
                {
                    LogId = AuditLog.Id,
                    EntityId = AuditLog.EntityId,
                    CompanyId = AuditLog.CompanyId,
                    Action = AuditLog.Action,
                    PerformedBy = AuditLog.PerformedBy,
                    Timestamp = AuditLog.Timestamp,
                    CreatedAt = AuditLog.CreatedAt,
                    Details = AuditLog.Details
                }).AsQueryable();

        public async Task<IEnumerable<AuditLogReadModel>> ToListAsync(IQueryable<AuditLogReadModel> queryable)
            => await Task.FromResult(queryable.ToList());

    }
}

