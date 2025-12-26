namespace ISO9001.Core.Interfaces.IncidentReports;

public interface IIncidentReportByEntityIdQuery
{
    Task<IEnumerable<IncidentReportResponse>> HandleAsync(string companyId, string entityId, DateTime? from, DateTime? end);
}
