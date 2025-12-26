namespace ISO9001.Core.Features.Interfaces.Internals.AuditReport;

public interface IGenerateAuditReportController
{
    Task<ReportViewModel> HandleAsync(string companyId, string entityId, DateTime? from, DateTime? end);
}
