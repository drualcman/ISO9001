namespace ISO9001.Core.Features.NonConformity.Controllers;

internal class GenerateNonConformityDetailsReportController(
    IGenerateNonConformityDetailsReportInputPort inputPort,
    IGenerateNonConformityDetailsReportOutputPort outputPort) : IGenerateNonConformityDetailsReport
{
    public async Task<ReportViewModel> HandleAsync(string companyId, string nonConformityId, DateTime? from, DateTime? end)
    {
        await inputPort.GenerateNonConformityDetailsReportAsync(companyId, nonConformityId, from, end);
        return outputPort.ReportViewModel;
    }
}
