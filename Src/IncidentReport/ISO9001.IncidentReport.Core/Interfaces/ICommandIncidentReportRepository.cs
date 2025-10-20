namespace ISO9001.IncidentReport.Core.Interfaces
{
    public interface ICommandIncidentReportRepository
    {
        Task RegisterIncidentReportAsync(IncidentReportDto incidentReport);
        Task SaveChangesAsync();
    }
}
