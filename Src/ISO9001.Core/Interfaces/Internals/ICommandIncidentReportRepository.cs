namespace ISO9001.Core.Interfaces.Internals;

internal interface ICommandIncidentReportRepository
{
    Task RegisterIncidentReportAsync(IncidentReportDto incidentReport);
    Task SaveChangesAsync();
}
