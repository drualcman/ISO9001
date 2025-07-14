using ISO9001.IncidentReports.Repositories.Entities;

namespace ISO9001.IncidentReports.Repositories.Interfaces
{
    public interface IRegisterIncidentReportDataContext
    {
        Task AddAsync(IncidentReport incidentReport);
        Task SaveChangesAsync();
    }
}
