namespace ISO9001.IncidentReport.Core.Internals.GenerateIncidentReportReport
{
    public interface IGenerateIncidentReportReportInputPort
    {
        ValueTask GenerateCustomerFeedbackReportAsync(string companyId, string entityId, DateTime? from, DateTime? end);
    }
}
