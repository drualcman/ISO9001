namespace ISO9001.Core.Features.AuditReport.Controllers;

internal class GenerateAuditReportController(
        IGenerateAuditReportInputPort inputPort,
        IGenerateAuditReportOutputPort outputPort) : IGenerateAuditReportController
{
    public async Task<ReportViewModel> HandleAsync(string companyId, string entityId, DateTime? from, DateTime? end)
    {
        await inputPort.GenerateAuditReportAsync(companyId, entityId, from, end);
        return outputPort.ReportViewModel;
    }
}
