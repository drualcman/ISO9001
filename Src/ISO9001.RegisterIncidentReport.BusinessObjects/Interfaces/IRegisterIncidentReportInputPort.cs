using ISO9001.Entities.Dtos;

namespace ISO9001.RegisterIncidentReport.BusinessObjects.Interfaces
{
    public interface IRegisterIncidentReportInputPort
    {
        Task HandleAsync(IncidentReportDto incidentReportDto);
    }
}
