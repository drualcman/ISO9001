namespace ISO9001.AuditLog.Core.Internals.GenerateAuditLogReport
{
    public interface IGenerateAuditLogReportController
    {
        Task<ReportViewModel> HandleAsync(string companyId, string entityId, DateTime? from, DateTime? end);
    }
}
