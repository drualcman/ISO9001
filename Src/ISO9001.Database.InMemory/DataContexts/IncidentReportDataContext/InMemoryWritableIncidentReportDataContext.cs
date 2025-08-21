using ISO9001.Repositories.IncidentReportRepositories.Entities;
using ISO9001.Repositories.IncidentReportRepositories.Interfaces;

namespace ISO9001.Database.InMemory.DataContexts.IncidentReportDataContext
{
    internal class InMemoryWritableIncidentReportDataContext : IWritableIncidentReportDataContext
    {
        public Task AddAsync(IncidentReport incidentReport)
        {
            var Record = new DataContexts.Entities.IncidentReport
            {
                Id = ++InMemoryIncidentReportStore.IncidentReportCurrentId,
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

            InMemoryIncidentReportStore.IncidentReports.Add(Record);
            return Task.CompletedTask;
        }

        public Task SaveChangesAsync()
        {
            return Task.CompletedTask;
        }
    }
}

