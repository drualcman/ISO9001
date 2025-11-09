using ISO9001.AuditLog.Core.Internals.GenerateAuditLogReport;

namespace ISO9001.AuditLog.Core.Handlers.GenerateAuditLogReport
{
    internal class GenerateAuditLogReportHandler(
        IGetAuditLogsByEntityIdInputPort inputPort,
        IGenerateAuditLogReportOutputPort outputPort): IGenerateAuditLogReportInputPort
    {
        public async ValueTask GenerateAuditLogReportAsync(string companyId, 
            string entityId, DateTime? from, DateTime? end)
        {
            DateTime UtcFrom = from != null ? from.Value.Date
                : DateTime.UtcNow.Date.AddDays(-30);

            DateTime UtcEnd = end != null ? end.Value.Date.AddDays(1).AddTicks(-1)
                : DateTime.UtcNow.Date.AddDays(1).AddTicks(-1);


            var AuditLogs = await inputPort.HandleAsync(companyId, entityId, UtcFrom, UtcEnd);
            await outputPort.Handle(AuditLogs, companyId);

        }
    }
}
