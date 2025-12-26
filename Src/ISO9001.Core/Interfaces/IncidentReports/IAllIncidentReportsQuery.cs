namespace ISO9001.Core.Interfaces.IncidentReports;

public interface IAllIncidentReportsQuery
{
    Task<IEnumerable<IncidentReportResponse>> HandleAsync(string id, DateTime? from, DateTime? end);

}
