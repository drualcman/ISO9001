namespace ISO9001.Core.Interfaces.IncidentReports;

public interface IRegisterIncidentReportInputPort
{
    Task HandleAsync(IncidentReportDto incidentReportDto);
}
