namespace ISO9001.IncidentReport.Core.Handlers.GenerateIncidentReportReport
{
    public class GenerateIncidentReportReportHandler(
        IGetIncidentReportByEntityIdInputPort inputPort,
        IGenerateIncidentReportReportOutputPort outputPort): IGenerateIncidentReportReportInputPort
    {
        public async ValueTask GenerateCustomerFeedbackReportAsync(string companyId, string entityId, DateTime? from, DateTime? end)
        {
            DateTime UtcFrom = from != null ? from.Value.Date
                : DateTime.UtcNow.Date.AddDays(-30);

            DateTime UtcEnd = end != null ? end.Value.Date.AddDays(1).AddTicks(-1)
                : DateTime.UtcNow.Date.AddDays(1).AddTicks(-1);

            var IncidentReports = await inputPort.HandleAsync(companyId, entityId, UtcFrom, UtcEnd);
            await outputPort.Handle(IncidentReports, companyId);
        }
    }
}
