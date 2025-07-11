using ISO9001.Entities.Responses;
using ISO9001.GetAllIncidentReports.BusinessObjects.Interfaces;
using ISO9001.IncidentReports.Repositories.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISO9001.IncidentReports.Repositories
{
    internal class GetAllIncidentReportsRepository(IGetAllIncidentReportsDataContext dataContext): IGetAllIncidentReportsRepository
    {
        public async Task<IEnumerable<IncidentReportResponse>> GetAllIncidentReportsAsync(string id, DateTime? from, DateTime? end)
        {
            var Query = dataContext.IncidentReports
                .Where(IncidentReport =>
                    IncidentReport.CompanyId == id &&
                    IncidentReport.ReportedAt >= from &&
                    IncidentReport.ReportedAt <= end)
                .OrderBy(IncidentReport => IncidentReport.ReportedAt);

            return await dataContext.ToListAsync(
                Query.Select(IncidentReport => new IncidentReportResponse(
                    IncidentReport.EntityId,
                    IncidentReport.ReportedAt,
                    IncidentReport.UserId,
                    IncidentReport.Description,
                    IncidentReport.AffectedProcess,
                    IncidentReport.Severity,
                    IncidentReport.Data
                    )));

        }
    }
}
