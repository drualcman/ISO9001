using ISO9001.AuditLogs.Repositories.Entities;
using ISO9001.AuditLogs.Repositories.Interfaces;

namespace ISO9001.Database.InMemory.DataContexts.AuditLogDataContexts
{
    internal class InMemoryRegisterAuditLogDataContext : IRegisterAuditLogDataContext
    {
        public Task AddAsync(AuditLog auditLog)
        {
            var Record = new DataContexts.Entities.AuditLog
            {
                Id = ++InMemoryAuditLogStore.CurrentId,
                CreatedAt = DateTime.UtcNow,
                EntityId = auditLog.EntityId,
                CompanyId = auditLog.CompanyId,
                Action = auditLog.Action,
                PerformedBy = auditLog.PerformedBy,
                Timestamp = auditLog.Timestamp,
                Details = auditLog.Details,
                Data = auditLog.Data
            };

            InMemoryAuditLogStore.AuditLogs.Add(Record);
            return Task.CompletedTask;
        }

        public Task SaveChangesAsync()
        {
            return Task.CompletedTask;
        }
    }
}
