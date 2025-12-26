namespace ISO9001.Core.Interfaces.AuditLogs;

public interface IGenerateAuditLogReportController
{
    Task<ReportViewModel> HandleAsync(string companyId, string entityId, DateTime? from, DateTime? end);
}
