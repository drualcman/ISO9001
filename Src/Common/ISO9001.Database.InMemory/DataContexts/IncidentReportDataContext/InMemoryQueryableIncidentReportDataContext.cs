namespace ISO9001.Database.InMemory.DataContexts.IncidentReportDataContext;

internal class InMemoryQueryableIncidentReportDataContext(
    InMemoryIncidentReportStore dataContext) : IQueryableIncidentReportDataContext
{
    public IQueryable<IncidentReportReadModel> IncidentReports =>
        dataContext.IncidentReports
        .Select(IncidentReport => new IncidentReportReadModel
        {
            Id = IncidentReport.Id,
            CompanyId = IncidentReport.CompanyId,
            EntityId = IncidentReport.EntityId,
            ReportedAt = IncidentReport.ReportedAt,
            CreatedAt = IncidentReport.CreatedAt,
            UserId = IncidentReport.UserId,
            Description = IncidentReport.Description,
            AffectedProcess = IncidentReport.AffectedProcess,
            Severity = IncidentReport.Severity,
            Data = IncidentReport.Data
        }).AsQueryable();

    public async Task<IEnumerable<IncidentReportReadModel>> ToListAsync(IQueryable<IncidentReportReadModel> queryable)
        => await Task.FromResult(queryable.ToList());

}

