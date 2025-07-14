using ISO9001.Entities.Responses;
using ISO9001.GetAllIncidentReports.BusinessObjects.Interfaces;

namespace ISO9001.GetAllIncidentReports.Core.Handlers
{
    internal class GetAllIncidentReportsHandler(IGetAllIncidentReportsRepository
        repository): IGetAllIncidentReportsInputPort
    {
        public async Task<IEnumerable<IncidentReportResponse>> HandleAsync(string id, DateTime? from, DateTime? end)
        {
            DateTime UtcFrom = from != null ? from.Value.Date
                : DateTime.UtcNow.Date.AddDays(-30);

            DateTime UtcEnd = end != null ? end.Value.Date.AddDays(1).AddTicks(-1)
                : DateTime.UtcNow.Date.AddDays(1).AddTicks(-1);

            return await repository.GetAllIncidentReportsAsync(id, UtcFrom, UtcEnd);
        }
    }
}
