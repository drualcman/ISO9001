namespace ISO9001.Core.Interfaces.IncidentReports;

public interface IGetAllIncidentReportsInputPort
{
    Task<IEnumerable<IncidentReportResponse>> HandleAsync(string id, DateTime? from, DateTime? end);

}
