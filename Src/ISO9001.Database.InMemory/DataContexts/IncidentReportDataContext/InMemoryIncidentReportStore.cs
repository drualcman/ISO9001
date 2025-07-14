using ISO9001.Database.InMemory.DataContexts.Entities;

namespace ISO9001.Database.InMemory.DataContexts.IncidentReportDataContext
{
    internal static class InMemoryIncidentReportStore
    {
        public static List<IncidentReport> IncidentReports { get; } = new();
        public static int IncidentReportCurrentId { get; set; }
    }
}
