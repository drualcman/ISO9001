using ISO9001.RegisterIncidentReport.Repositories.Entities;

namespace ISO9001.RegisterIncidentReport.Repositories.Interfaces
{
    public interface IRegisterIncidentReportDataContext
    {
        Task AddAsync(IncidentReport incidentReport);
        Task SaveChangesAsync();
    }
}
