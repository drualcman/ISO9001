namespace ISO9001.AuditReport.Core.Controllers.GenerateAuditReport
{
    internal class GenerateAuditReportController(
        IGenerateAuditReportInputPort inputPort,
        IGenerateAuditReportOutputPort outputPort) : IGenerateAuditReportController
    {
        public async Task<byte[]> HandleAsync(string companyId, string entityId, DateTime? from, DateTime? end)
        {
            await inputPort.GenerateAuditReportAsync(companyId, entityId, from, end);
            return outputPort.PdfBytes;

        }
    }
}
