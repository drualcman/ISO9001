using ISO9001.Entities.Responses;

namespace ISO9001.GetAuditLogById.BusinessObjects.Interfaces
{
    public interface IGetAuditLogByIdRepository
    {
        Task<AuditLogResponse> GetAuditLogByIdAsync(string companyId, int id);

        Task<bool> AuditLogExitsByIdAsync(string companyId, int id);
    }
}
