namespace ISO9001.Core.Features.Interfaces.Internals.IncidentReport;

public interface IGenerateIncidentReportReportInputPort
{
    ValueTask GenerateCustomerFeedbackReportAsync(string companyId, string entityId, DateTime? from, DateTime? end);
}
