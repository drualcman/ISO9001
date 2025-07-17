using ISO9001.IncidentReports.Repositories.Entities;

namespace ISO9001.IncidentReports.Repositories.Interfaces
{
    public interface IWritableIncidentReportDataContext
    {
        Task AddAsync(IncidentReport incidentReport);
        Task SaveChangesAsync();
    }
}

