using ISO9001.Entities.Dtos;
using ISO9001.RegisterAuditLog.BusinessObjects.Interfaces;

namespace ISO9001.RegisterAuditLog.Core.Handlers
{
    internal class RegisterAuditLogHandler(IRegisterAuditLogRepository repository) : IRegisterAuditLogInputPort
    {
        public async Task HandleAsync(AuditLogDto auditLog)
        {
            await repository.RegisterAuditLogAsync(auditLog);
            await repository.SaveChangesAsync();
        }
    }
}
