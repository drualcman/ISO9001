namespace ISO9001.Core.Features.Interfaces.Internals.AuditLog
{
    public interface IGenerateAuditLogReportController
    {
        Task<ReportViewModel> HandleAsync(string companyId, string entityId, DateTime? from, DateTime? end);
    }
}
