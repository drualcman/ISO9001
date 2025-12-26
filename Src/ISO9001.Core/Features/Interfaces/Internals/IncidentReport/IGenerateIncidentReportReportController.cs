namespace ISO9001.Core.Features.Interfaces.Internals.IncidentReport;

public interface IGenerateIncidentReportReportController
{
    Task<ReportViewModel> HandleAsync(string companyId, string entityId, DateTime? from, DateTime? end);

}
