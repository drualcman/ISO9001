namespace ISO9001.AuditReport.Core.Controllers.GenerateAuditReport
{
    internal class GenerateAuditReportController(
        IGenerateAuditReportInputPort inputPort) : IGenerateAuditReportController
    {
        public async Task HandleAsync(string companyId, string entityId, DateTime? from, DateTime? end)
        {
            await inputPort.GenerateAuditReportAsync(companyId, entityId, from, end);

        }
    }
}
