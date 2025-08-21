using ISO9001.Repositories.IncidentReportRepositories.Entities;

namespace ISO9001.Repositories.IncidentReportRepositories.Interfaces
{
    public interface IWritableIncidentReportDataContext
    {
        Task AddAsync(IncidentReport incidentReport);
        Task SaveChangesAsync();
    }
}

