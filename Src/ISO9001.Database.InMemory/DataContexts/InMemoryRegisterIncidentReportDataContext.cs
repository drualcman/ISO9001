using ISO9001.RegisterIncidentReport.Repositories.Entities;
using ISO9001.RegisterIncidentReport.Repositories.Interfaces;

namespace ISO9001.Database.InMemory.DataContexts
{
    internal class InMemoryRegisterIncidentReportDataContext : IRegisterIncidentReportDataContext
    {
        private static readonly List<DataContexts.Entities.IncidentReport> incidentReportList = new();
        private static int currentId = 0;

        public Task AddAsync(IncidentReport incidentReport)
        {
            var Record = new DataContexts.Entities.IncidentReport
            {
                Id = +currentId,
                CompanyId = incidentReport.CompanyId,
                EntityId = incidentReport.EntityId,
                ReportedAt = incidentReport.ReportedAt,
                CreatedAt = DateTime.UtcNow,
                UserId = incidentReport.UserId,
                Description = incidentReport.Description,
                AffectedProcess = incidentReport.AffectedProcess,
                Severity = incidentReport.Severity,
                Data = incidentReport.Data
            };

            incidentReportList.Add(Record);
            return Task.CompletedTask;
        }

        public Task SaveChangesAsync()
        {
            return Task.CompletedTask;
        }
    }
}
