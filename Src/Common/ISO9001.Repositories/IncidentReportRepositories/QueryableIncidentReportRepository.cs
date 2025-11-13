using ISO9001.Repositories.IncidentReportRepositories.Interfaces;

namespace ISO9001.Repositories.IncidentReportRepositories
{
    internal class QueryableIncidentReportRepository
        (IQueryableIncidentReportDataContext dataContext) : IQueryableIncidentReportRepository
    {
        public async Task<IEnumerable<IncidentReportResponse>> GetAllIncidentReportsAsync(string id, DateTime? from, DateTime? end)
        {
            var Query = dataContext.IncidentReports
                .Where(IncidentReport =>
                    IncidentReport.CompanyId == id &&
                    IncidentReport.ReportedAt >= from &&
                    IncidentReport.ReportedAt <= end)
                .OrderBy(IncidentReport => IncidentReport.ReportedAt);

            var IncidentReports = await dataContext.ToListAsync(Query);

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
            var Query = dataContext.IncidentReports
                .Where(IncidentReport =>
                    IncidentReport.CompanyId == id &&
                    IncidentReport.EntityId == entityId &&
                    IncidentReport.ReportedAt >= from &&
                    IncidentReport.ReportedAt <= end)
                .OrderBy(IncidentReport => IncidentReport.ReportedAt);

            var IncidentReports = await dataContext.ToListAsync(Query);

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

        public Task<IncidentReportResponse> GetIncidentReportByIdAsync(string companyId, int id)
        {
            var IncidentReport = dataContext.IncidentReports
                .FirstOrDefault(IncidentReport => IncidentReport.CompanyId == companyId &&
                IncidentReport.Id == id);

            return Task.FromResult(new IncidentReportResponse(
                IncidentReport.EntityId,
                IncidentReport.ReportedAt,
                IncidentReport.UserId,
                IncidentReport.Description,
                IncidentReport.AffectedProcess,
                IncidentReport.Severity,
                IncidentReport.Data));
        }

        public Task<bool> IncidentReportExists(string companyId, int id)
        {
            var IncidentReport = dataContext.IncidentReports
                .FirstOrDefault(IncidentReport => IncidentReport.CompanyId == companyId &&
                IncidentReport.Id == id);

            return Task.FromResult(IncidentReport != null);
        }
    }
}
