namespace ISO9001.IncidentReport.Core.Internals.RegisterIncidentReport
{
    public interface IRegisterIncidentReportInputPort
    {
        Task HandleAsync(IncidentReportDto incidentReportDto);
    }
}
