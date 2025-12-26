namespace ISO9001.Core.Interfaces.IncidentReports;

public interface IRegisterIncidentReport
{
    Task HandleAsync(IncidentReportDto incidentReportDto);
}
