namespace ISO9001.Core.Interfaces.AuditLogs;

public interface IQueryableAuditLogDataContext
{
    IQueryable<AuditLogReadModel> AuditLogs { get; }
    Task<IEnumerable<AuditLogReadModel>> ToListAsync(
        IQueryable<AuditLogReadModel> queryable);
}

