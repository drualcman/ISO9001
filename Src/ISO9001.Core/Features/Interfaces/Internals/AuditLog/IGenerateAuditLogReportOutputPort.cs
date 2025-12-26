using ISO9001.Core.Responses;

namespace ISO9001.Core.Features.Interfaces.Internals.AuditLog
{
    internal interface IGenerateAuditLogReportOutputPort
    {
        public ReportViewModel ReportViewModel { get; }
        Task Handle(IEnumerable<AuditLogResponse> auditLogResponses, string companyId);
    }
}
