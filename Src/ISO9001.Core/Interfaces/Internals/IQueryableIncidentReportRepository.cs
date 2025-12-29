namespace ISO9001.Core.Interfaces.Internals;

internal interface IQueryableIncidentReportRepository
{
    Task<IEnumerable<IncidentReportResponse>> GetAllIncidentReportsAsync(string id, DateTime? from, DateTime? end);
    Task<IEnumerable<IncidentReportResponse>> GetIncidentReportByEntityIdAsync(string id, string entityId, DateTime? from, DateTime? end);

    Task<IncidentReportResponse> GetIncidentReportByIdAsync(string companyId, string id);

    Task<bool> IncidentReportExists(string companyId, string id);
}
