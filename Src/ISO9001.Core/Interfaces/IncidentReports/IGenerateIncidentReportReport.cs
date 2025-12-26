namespace ISO9001.Core.Interfaces.IncidentReports;

public interface IGenerateIncidentReportReport
{
    Task<ReportViewModel> HandleAsync(string companyId, string entityId, DateTime? from, DateTime? end);

}
