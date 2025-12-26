namespace ISO9001.Database.InMemory.DataContexts.IncidentReportDataContext;

internal class InMemoryWritableIncidentReportDataContext(
    InMemoryIncidentReportStore dataContext) : IWritableIncidentReportDataContext
{
    public Task AddAsync(Core.Entities.IncidentReport incidentReport)
    {
        var Record = new Entities.IncidentReport
        {
            Id = ++dataContext.IncidentReportCurrentId,
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

        dataContext.IncidentReports.Add(Record);
        return Task.CompletedTask;
    }

    public Task SaveChangesAsync()
    {
        return Task.CompletedTask;
    }
}

