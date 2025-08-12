using ISO9001.Entities.Responses;
using ISO9001.GetAuditLogById.BusinessObjects.Interfaces;

namespace ISO9001.GetAuditLogById.Core.Handler
{
    internal class GetAuditLogByIdHandler(IGetAuditLogByIdRepository repository) : IGetAuditLogByIdInputPort
    {
        public async Task<AuditLogResponse> HandleAsync(string companyId, int id)
        {
            var AuditLogExists = await repository.AuditLogExitsByIdAsync(companyId, id);

            if(!AuditLogExists)
            {
                throw new KeyNotFoundException($"AuditLog with Id '{id}' doesn't exist in the company: '{companyId}'");
            }
            else
            {
                return await repository.GetAuditLogByIdAsync(companyId, id);
            }


        }

    }
}
