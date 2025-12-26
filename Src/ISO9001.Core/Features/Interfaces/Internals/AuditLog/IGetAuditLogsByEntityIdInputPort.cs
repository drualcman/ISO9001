using ISO9001.Core.Responses;

namespace ISO9001.Core.Features.Interfaces.Internals.AuditLog
{
    public interface IGetAuditLogsByEntityIdInputPort
    {
        Task<IEnumerable<AuditLogResponse>> HandleAsync(string id, string entityId, DateTime? from, DateTime? end);
    }
}
