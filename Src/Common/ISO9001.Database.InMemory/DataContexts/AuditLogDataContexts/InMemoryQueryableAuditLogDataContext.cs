using System.Linq.Expressions;

namespace ISO9001.Database.InMemory.DataContexts.AuditLogDataContexts;

internal class InMemoryQueryableAuditLogDataContext(
    InMemoryAuditLogStore dataContext) : IQueryableAuditLogDataContext
{
    private IQueryable<AuditLogReadModel> AuditLogs =>
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

    public async Task<IEnumerable<AuditLogReadModel>> ToListAsync(
        Expression<Func<AuditLogReadModel, bool>> filter = null,
        Func<IQueryable<AuditLogReadModel>, IOrderedQueryable<AuditLogReadModel>> orderBy = null)
    {
        IQueryable<AuditLogReadModel> query = AuditLogs;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (orderBy != null)
        {
            query = orderBy(query);
        }

        var data = query.ToList();
        return await Task.FromResult(data);
    }

}

