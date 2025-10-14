namespace ISO9001.Repositories.IncidentReportRepositories.Interfaces
{
    public interface IWritableIncidentReportDataContext
    {
        Task AddAsync(Entities.IncidentReport incidentReport);
        Task SaveChangesAsync();
    }
}

