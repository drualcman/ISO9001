using ISO9001.Entities.Responses;
using ISO9001.GetIncidentReportById.BusinessObjects.Interfaces;
using ISO9001.Repositories.IncidentReportRepositories.Interfaces;

namespace ISO9001.Repositories.IncidentReportRepositories
{
    internal class GetIncidentReportByIdRepository
        (IQueryableIncidentReportDataContext dataContext): IGetIncidentReportByIdRepository
    {
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
