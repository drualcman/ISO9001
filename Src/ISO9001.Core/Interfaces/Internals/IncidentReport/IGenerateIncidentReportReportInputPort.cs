namespace ISO9001.Core.Interfaces.Internals.IncidentReport;

internal interface IGenerateIncidentReportReportInputPort
{
    ValueTask GenerateCustomerFeedbackReportAsync(string companyId, string entityId, DateTime? from, DateTime? end);
}
