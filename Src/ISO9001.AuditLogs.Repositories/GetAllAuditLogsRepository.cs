using ISO9001.AuditLogs.Repositories.Entities;
using ISO9001.AuditLogs.Repositories.Interfaces;
using ISO9001.Entities.Responses;
using ISO9001.GetAllAuditLogs.BusinessObjects;

namespace ISO9001.AuditLogs.Repositories
{
    internal class GetAllAuditLogsRepository(IQueryableAuditLogDataContext dataContext) : IGetAllAuditLogsRepository
    {
        public async Task<IEnumerable<AuditLogResponse>> GetAllAuditLogsOrderedByIdAscendingAsync(
            string id, DateTime? from, DateTime? end)
        {
            IQueryable<AuditLogReadModel> Query = dataContext.AuditLogs
                .Where(AuditLog => AuditLog.CompanyId == id &&
                                AuditLog.Timestamp >= from &&
                                AuditLog.Timestamp <= end)
                .OrderBy(AuditLog => AuditLog.LogId);

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
