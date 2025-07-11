using ISO9001.Entities.Responses;

namespace ISO9001.GetAllIncidentReports.BusinessObjects.Interfaces
{
    public interface IGetAllIncidentReportsInputPort
    {
        Task<IEnumerable<IncidentReportResponse>> HandleAsync(string id, DateTime? from, DateTime? end);
    }
}
