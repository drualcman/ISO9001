using ISO9001.Core.Responses;

namespace ISO9001.Core.Features.Interfaces.Internals.AuditLog
{
    public interface IGetAllAuditLogsInputPort
    {
        Task<IEnumerable<AuditLogResponse>> HandleAsync(string id, DateTime? from, DateTime? end);
    }
}
