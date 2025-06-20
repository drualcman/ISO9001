using ISO9001.AuditLogs.Repositories.Entities;
using ISO9001.AuditLogs.Repositories.Interfaces;

namespace ISO9001.Database.InMemory.DataContexts.AuditLogDataContexts
{
    internal class InMemoryGetAuditLogsByActionDataContext : IGetAuditLogsByActionDataContext
    {
        public IQueryable<AuditLogReadModel> AuditLogs =>
            InMemoryAuditLogStore.AuditLogs
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

        public async Task<IEnumerable<ReturnType>> ToListAsync<ReturnType>(IQueryable<ReturnType> queryable)
            => await Task.FromResult(queryable.ToList());
    }
}
