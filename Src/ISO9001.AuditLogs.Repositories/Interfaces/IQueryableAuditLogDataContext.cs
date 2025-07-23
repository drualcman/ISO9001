using ISO9001.AuditLogs.Repositories.Entities;

namespace ISO9001.AuditLogs.Repositories.Interfaces
{
    public interface IQueryableAuditLogDataContext
    {
        IQueryable<AuditLogReadModel> AuditLogs { get; }
        Task<IEnumerable<AuditLogReadModel>> ToListAsync(
            IQueryable<AuditLogReadModel> queryable);
    }
}

