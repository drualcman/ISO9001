namespace ISO9001.Core.Interfaces.AuditLogs;

public interface IQueryableAuditLogDataContext
{
    Task<IEnumerable<AuditLogReadModel>> ToListAsync(         // TODO: discutir esto
        Expression<Func<AuditLogReadModel, bool>> filter = null,
        Func<IQueryable<AuditLogReadModel>, IOrderedQueryable<AuditLogReadModel>> orderBy = null);
}

