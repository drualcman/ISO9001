using ISO9001.Entities.Responses;

namespace ISO9001.GetIncidentReportById.BusinessObjects.Interfaces
{
    public interface IGetIncidentReportByIdRepository
    {
        Task<IncidentReportResponse> GetIncidentReportByIdAsync(string companyId, int id);

        Task<bool> IncidentReportExists(string companyId, int id);
    }
}
