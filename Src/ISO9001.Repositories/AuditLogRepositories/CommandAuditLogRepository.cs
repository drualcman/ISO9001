namespace ISO9001.Repositories.AuditLogRepositories
{
    internal class CommandAuditLogRepository(
        IWritableAuditLogDataContext dataContext) : ICommandAuditLogRepository
    {
        public async Task RegisterAuditLogAsync(AuditLogDto auditLogDto)
        {

            var NewAuditiLog = new Entities.AuditLog
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
