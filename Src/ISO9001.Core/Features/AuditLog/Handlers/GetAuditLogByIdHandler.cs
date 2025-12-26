using ISO9001.Core.Responses;

namespace ISO9001.Core.Features.AuditLog.Handlers;

internal class GetAuditLogByIdHandler(IQueryableAuditLogRepository repository) : IGetAuditLogByIdInputPort
{
    public async Task<AuditLogResponse> HandleAsync(string companyId, int id)
    {
        var AuditLogExists = await repository.AuditLogExitsByIdAsync(companyId, id);

        if (!AuditLogExists)
        {
            throw new KeyNotFoundException($"AuditLog with Id '{id}' doesn't exist in the company: '{companyId}'");
        }
        else
        {
            return await repository.GetAuditLogByIdAsync(companyId, id);
        }


    }

}
