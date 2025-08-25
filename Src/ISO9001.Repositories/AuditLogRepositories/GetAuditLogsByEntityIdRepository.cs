using ISO9001.Entities.Responses;
using ISO9001.GetAuditLogsByEntityIdBusinessObjects.Interfaces;
using ISO9001.Repositories.AuditLogRepositories.Entities;
using ISO9001.Repositories.AuditLogRepositories.Interfaces;

namespace ISO9001.Repositories.AuditLogRepositories
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

            var AuditLogs = await dataContext.ToListAsync(Query);

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
}
