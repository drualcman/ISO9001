using ISO9001.AuditLogs.Repositories.Entities;
using ISO9001.AuditLogs.Repositories.Interfaces;
using ISO9001.Entities.Dtos;
using ISO9001.RegisterAuditLog.BusinessObjects.Interfaces;

namespace ISO9001.AuditLogs.Repositories
{
    internal class RegisterAuditLogRepository(
        IRegisterAuditLogDataContext dataContext) : IRegisterAuditLogRepository
    {
        public async Task RegisterAuditLogAsync(AuditLogDto auditLogDto)
        {

            var NewAuditiLog = new AuditLog
            {
                EntityId = auditLogDto.EntityId,
                CompanyId = auditLogDto.CompanyId,
                Action = auditLogDto.Action,
                PerformedBy = auditLogDto.PerformedBy,
                Timestamp = auditLogDto.Timestamp,
                Details = auditLogDto.Details,
                Data = auditLogDto.Data,
            };

            await dataContext.AddAsync(NewAuditiLog);

        }

        public async Task SaveChangesAsync() => await dataContext.SaveChangesAsync();

    }
}
