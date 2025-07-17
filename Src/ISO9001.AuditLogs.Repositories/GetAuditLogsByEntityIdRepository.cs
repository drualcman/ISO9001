using ISO9001.AuditLogs.Repositories.Entities;
using ISO9001.AuditLogs.Repositories.Interfaces;
using ISO9001.Entities.Responses;
using ISO9001.GetAuditLogsByEntityIdBusinessObjects.Interfaces;

namespace ISO9001.AuditLogs.Repositories
{
    internal class GetAuditLogsByEntityIdRepository(
        IQueryableAuditLogDataContext dataContext) : IGetAuditLogsByEntityIdRepository
    {
        public async Task<IEnumerable<AuditLogResponse>> GetAuditLogsByEntityIdAsync(string id, string entityId,
            DateTime? from, DateTime? end)
        {
            IQueryable<AuditLogReadModel> Query = dataContext.AuditLogs
                .Where(AuditLog => AuditLog.CompanyId == id &&
                            AuditLog.EntityId == entityId &&
                            AuditLog.Timestamp >= from &&
                            AuditLog.Timestamp <= end);

            return await dataContext.ToListAsync(Query
                .Select(AuditLog => new AuditLogResponse(
                    AuditLog.LogId,
                    AuditLog.EntityId,
                    AuditLog.Action,
                    AuditLog.PerformedBy,
                    AuditLog.Timestamp,
                    AuditLog.CreatedAt,
                    AuditLog.Details)));
        }
    }
}
