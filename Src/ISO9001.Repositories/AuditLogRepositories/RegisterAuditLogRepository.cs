using ISO9001.Entities.Dtos;
using ISO9001.RegisterAuditLog.BusinessObjects.Interfaces;
using ISO9001.Repositories.AuditLogRepositories.Entities;
using ISO9001.Repositories.AuditLogRepositories.Interfaces;

namespace ISO9001.Repositories.AuditLogRepositories
{
    internal class RegisterAuditLogRepository(
        IWritableAuditLogDataContext dataContext) : IRegisterAuditLogRepository
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
