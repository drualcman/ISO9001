namespace ISO9001.Database.InMemory.DataContexts.IncidentReportDataContext;

internal class InMemoryIncidentReportStore
{
    public List<Entities.IncidentReport> IncidentReports { get; } = new();
    public int IncidentReportCurrentId { get; set; }
}
