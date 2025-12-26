namespace ISO9001.Core.Interfaces.Internals.AuditLog;

internal interface IGenerateAuditLogReportOutputPort
{
    public ReportViewModel ReportViewModel { get; }
    Task Handle(IEnumerable<AuditLogResponse> auditLogResponses, string companyId);
}
