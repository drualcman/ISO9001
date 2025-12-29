namespace ISO9001.Core.Features.IncidentReport.Handlers;

internal class GetIncidentReportByIdHandler(
    IQueryableIncidentReportRepository repository) : IGetIncidentReportByIdInputPort
{
    public async Task<IncidentReportResponse> HandleAsync(string companyId, string id)
    {
        var IncidentReportExists = await repository.IncidentReportExists(companyId, id);

        if (!IncidentReportExists)
        {
            throw new KeyNotFoundException($"IncidentReport with Id '{id}' doesn't exist in the company: '{companyId}'");
        }
        else
        {
            return await repository.GetIncidentReportByIdAsync(companyId, id);
        }

    }
}
