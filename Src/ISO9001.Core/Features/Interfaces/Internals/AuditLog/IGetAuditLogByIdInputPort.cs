using ISO9001.Core.Responses;

namespace ISO9001.Core.Features.Interfaces.Internals.AuditLog
{
    public interface IGetAuditLogByIdInputPort
    {
        Task<AuditLogResponse> HandleAsync(string companyId, int id);
    }
}
