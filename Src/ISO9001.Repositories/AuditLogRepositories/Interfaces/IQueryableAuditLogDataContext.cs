namespace ISO9001.Repositories.AuditLogRepositories.Interfaces
{
    public interface IQueryableAuditLogDataContext
    {
        IQueryable<AuditLogReadModel> AuditLogs { get; }
        Task<IEnumerable<AuditLogReadModel>> ToListAsync(
            IQueryable<AuditLogReadModel> queryable);
    }
}

