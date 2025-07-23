using ISO9001.AuditLogs.Repositories.Entities;
using ISO9001.AuditLogs.Repositories.Interfaces;
using ISO9001.Entities.Responses;
using ISO9001.GetAuditLogsByAction.BusinessObjects.Interfaces;

namespace ISO9001.AuditLogs.Repositories
{
    internal class GetAuditLogsByActionRepository(
        IQueryableAuditLogDataContext dataContext) : IGetAuditLogsByActionRepository
    {
        public async Task<IEnumerable<AuditLogResponse>> GetAuditLogsByActionAsync(string id, string action,
            DateTime? from, DateTime? end)
        {
            IQueryable<AuditLogReadModel> Query = dataContext.AuditLogs
                .Where(AuditLog => AuditLog.CompanyId == id &&
                                AuditLog.Action == action &&
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
