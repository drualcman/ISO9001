using ISO9001.AuditLogs.Repositories.Entities;

namespace ISO9001.AuditLogs.Repositories.Interfaces
{
    public interface IGetAuditLogsByActionDataContext
    {
        IQueryable<AuditLogReadModel> AuditLogs { get; }
        Task<IEnumerable<ReturnType>> ToListAsync<ReturnType>(
            IQueryable<ReturnType> queryable);
    }
}
