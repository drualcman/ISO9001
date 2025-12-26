namespace ISO9001.Core.Interfaces.AuditReports;

public interface IGenerateAuditReport
{
    Task<ReportViewModel> HandleAsync(string companyId, string entityId, DateTime? from, DateTime? end);
}
