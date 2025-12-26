namespace ISO9001.Core.Features.NonConformity.Controllers;

internal class GenerateNonConformityMasterReportController(
    IGenerateNonConformityMasterReportInputPort inputPort,
    IGenerateNonConformityMasterReportOutputPort outputPort) : IGenerateNonConformityMasterReportController
{
    public async Task<ReportViewModel> HandleAsync(string companyId, string entityId, DateTime? from, DateTime? end)
    {
        await inputPort.GenerateNonConformityMasterReportAsync(companyId, entityId, from, end);
        return outputPort.ReportViewModel;
    }
}
