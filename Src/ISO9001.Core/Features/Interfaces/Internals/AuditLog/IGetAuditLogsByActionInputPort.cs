using ISO9001.Core.Responses;

namespace ISO9001.Core.Features.Interfaces.Internals.AuditLog
{
    public interface IGetAuditLogsByActionInputPort
    {
        Task<IEnumerable<AuditLogResponse>> HandleAsync(string id, string action, DateTime? from, DateTime? end);
    }
}
