namespace ISO9001.IncidentReport.Core.Interfaces
{
    public interface IQueryableIncidentReportRepository
    {
        Task<IEnumerable<IncidentReportResponse>> GetAllIncidentReportsAsync(string id, DateTime? from, DateTime? end);

        Task<IncidentReportResponse> GetIncidentReportByIdAsync(string companyId, int id);

        Task<bool> IncidentReportExists(string companyId, int id);
    }
}
