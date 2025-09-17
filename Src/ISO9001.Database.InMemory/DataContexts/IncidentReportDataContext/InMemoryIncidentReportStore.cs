using ISO9001.Database.InMemory.DataContexts.Entities;

namespace ISO9001.Database.InMemory.DataContexts.IncidentReportDataContext
{
    internal class InMemoryIncidentReportStore
    {
        public List<IncidentReport> IncidentReports { get; } = new();
        public int IncidentReportCurrentId { get; set; }
    }
}
