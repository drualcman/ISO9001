using ISO9001.Entities.Responses;

namespace ISO9001.GetAllIncidentReports.BusinessObjects.Interfaces
{
    public interface IGetAllIncidentReportsRepository
    {
        Task<IEnumerable<IncidentReportResponse>> GetAllIncidentReportsAsync(string id, DateTime? from, DateTime? end);
    }
}
