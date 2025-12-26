namespace ISO9001.Core.Interfaces
{
    public interface IWritableIncidentReportDataContext
    {
        Task AddAsync(Entities.IncidentReport incidentReport);
        Task SaveChangesAsync();
    }
}

