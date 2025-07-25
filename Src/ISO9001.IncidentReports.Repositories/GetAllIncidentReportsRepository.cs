using ISO9001.Entities.Responses;
using ISO9001.GetAllIncidentReports.BusinessObjects.Interfaces;
using ISO9001.IncidentReports.Repositories.Interfaces;

namespace ISO9001.IncidentReports.Repositories
{
    internal class GetAllIncidentReportsRepository(IQueryableIncidentReportDataContext dataContext) : IGetAllIncidentReportsRepository
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
    }
}
