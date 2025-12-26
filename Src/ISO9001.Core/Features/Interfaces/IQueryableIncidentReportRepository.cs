using ISO9001.Core.Responses;

namespace ISO9001.Core.Features.Interfaces;

public interface IQueryableIncidentReportRepository
{
    Task<IEnumerable<IncidentReportResponse>> GetAllIncidentReportsAsync(string id, DateTime? from, DateTime? end);
    Task<IEnumerable<IncidentReportResponse>> GetIncidentReportByEntityIdAsync(string id, string entityId, DateTime? from, DateTime? end);

    Task<IncidentReportResponse> GetIncidentReportByIdAsync(string companyId, int id);

    Task<bool> IncidentReportExists(string companyId, int id);
}
