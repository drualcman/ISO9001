using ISO9001.Entities.Responses;

namespace ISO9001.GetAuditLogById.BusinessObjects.Interfaces
{
    public interface IGetAuditLogByIdInputPort
    {
        Task<AuditLogResponse> HandleAsync(string companyId, int id);
    }
}
