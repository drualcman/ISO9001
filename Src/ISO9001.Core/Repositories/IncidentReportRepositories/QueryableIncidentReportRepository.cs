namespace ISO9001.Core.Repositories.IncidentReportRepositories;

internal class QueryableIncidentReportRepository
    (IQueryableIncidentReportDataContext dataContext) : IQueryableIncidentReportRepository
{
    public async Task<IEnumerable<IncidentReportResponse>> GetAllIncidentReportsAsync(string id, DateTime? from, DateTime? end)
    {
        var IncidentReports = await dataContext.ToListAsync(
            IncidentReport => IncidentReport.CompanyId == id &&
                IncidentReport.ReportedAt >= from &&
                IncidentReport.ReportedAt <= end,
            IncidentReport => IncidentReport.OrderBy(IncidentReport =>
                IncidentReport.ReportedAt));

        return IncidentReports.Select(
            IncidentReport => new IncidentReportResponse(
                IncidentReport.EntityId,
                IncidentReport.ReportedAt,
                IncidentReport.UserId,
                IncidentReport.Description,
                IncidentReport.AffectedProcess,
                IncidentReport.Severity,
                IncidentReport.Data
                ));
    }

    public async Task<IEnumerable<IncidentReportResponse>> GetIncidentReportByEntityIdAsync(string id, string entityId, DateTime? from, DateTime? end)
    {
        var IncidentReports = await dataContext.ToListAsync(
            IncidentReport => IncidentReport.CompanyId == id &&
                IncidentReport.EntityId == entityId &&
                IncidentReport.ReportedAt >= from &&
                IncidentReport.ReportedAt <= end,
            IncidentReport => IncidentReport.OrderBy(IncidentReport =>
                IncidentReport.ReportedAt));

        return IncidentReports.Select(
            IncidentReport => new IncidentReportResponse(
                IncidentReport.EntityId,
                IncidentReport.ReportedAt,
                IncidentReport.UserId,
                IncidentReport.Description,
                IncidentReport.AffectedProcess,
                IncidentReport.Severity,
                IncidentReport.Data
                ));
    }

    public async Task<IncidentReportResponse> GetIncidentReportByIdAsync(string companyId, string id)
    {
        var Data = await dataContext.ToListAsync(
            IncidentReport => IncidentReport.CompanyId == companyId &&
            IncidentReport.Id == id,
            o => o.OrderBy(a => a.ReportedAt));

        var IncidentReport = Data.FirstOrDefault();

        if (IncidentReport == null)
            return null;

        return new IncidentReportResponse(
            IncidentReport.EntityId,
            IncidentReport.ReportedAt,
            IncidentReport.UserId,
            IncidentReport.Description,
            IncidentReport.AffectedProcess,
            IncidentReport.Severity,
            IncidentReport.Data);
    }

    public async Task<bool> IncidentReportExists(string companyId, string id)
    {
        var IncidentReport = await dataContext.ToListAsync(
            IncidentReport => IncidentReport.CompanyId == companyId &&
                IncidentReport.Id == id);

        return IncidentReport.Any();
    }
}
