namespace ISO9001.Core.Features.AuditLog.Controllers;

internal class GenerateAuditLogReportController(
        IGenerateAuditLogReportInputPort inputPort,
        IGenerateAuditLogReportOutputPort outputPort) : IGenerateAuditLogReportController
{
    public async Task<ReportViewModel> HandleAsync(string companyId, string entityId, DateTime? from, DateTime? end)
    {
        await inputPort.GenerateAuditLogReportAsync(companyId, entityId, from, end);
        return outputPort.ReportViewModel;
    }
}
