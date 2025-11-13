namespace ISO9001.NonConformity.Core.Controllers.GenerateNonConformityDetailsReport;
internal class GenerateNonConformityDetailsReportController(
    IGenerateNonConformityDetailsReportInputPort inputPort,
    IGenerateNonConformityDetailsReportOutputPort outputPort): IGenerateNonConformityDetailsReportController
{
    public async Task<ReportViewModel> HandleAsync(string companyId, string nonConformityId, DateTime? from, DateTime? end)
    {
        await inputPort.GenerateNonConformityDetailsReportAsync(companyId, nonConformityId, from, end);
        return outputPort.ReportViewModel;
    }
}
