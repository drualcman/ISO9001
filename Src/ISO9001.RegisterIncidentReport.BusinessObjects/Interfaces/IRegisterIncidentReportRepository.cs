using ISO9001.Entities.Dtos;

namespace ISO9001.RegisterIncidentReport.BusinessObjects.Interfaces
{
    public interface IRegisterIncidentReportRepository
    {
        Task RegisterIncidentReportAsync(IncidentReportDto incidentReport);
        Task SaveChangesAsync();
    }
}
