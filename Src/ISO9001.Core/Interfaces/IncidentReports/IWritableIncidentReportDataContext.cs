namespace ISO9001.Core.Interfaces.IncidentReports
{
    public interface IWritableIncidentReportDataContext
    {
        Task AddAsync(IncidentReport incidentReport);
        Task SaveChangesAsync();
    }
}

