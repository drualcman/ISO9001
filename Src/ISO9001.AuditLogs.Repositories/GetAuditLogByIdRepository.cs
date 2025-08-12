using ISO9001.AuditLogs.Repositories.Interfaces;
using ISO9001.Entities.Responses;
using ISO9001.GetAuditLogById.BusinessObjects.Interfaces;

namespace ISO9001.AuditLogs.Repositories
{
    internal class GetAuditLogByIdRepository(
        IQueryableAuditLogDataContext dataContext) : IGetAuditLogByIdRepository
    {
        public Task<bool> AuditLogExitsByIdAsync(string companyId, int id)
        {
            var AuditLog = dataContext.AuditLogs.FirstOrDefault
                (AuditLog => AuditLog.CompanyId == companyId &&
                    AuditLog.LogId == id);

            return Task.FromResult(AuditLog != null);
        }

        public Task<AuditLogResponse> GetAuditLogByIdAsync(string companyId, int id)
        {
            var AuditLog = dataContext
                .AuditLogs.FirstOrDefault(
                AuditLog => AuditLog.CompanyId == companyId &&
                    AuditLog.LogId == id);

            return Task.FromResult(new AuditLogResponse(
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
