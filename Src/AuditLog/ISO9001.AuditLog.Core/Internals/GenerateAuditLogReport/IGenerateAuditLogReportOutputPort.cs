using DigitalDoor.Reporting.Entities.ViewModels;

namespace ISO9001.AuditLog.Core.Internals.GenerateAuditLogReport
{
    internal interface IGenerateAuditLogReportOutputPort
    {
        public ReportViewModel ReportViewModel { get; }
        Task Handle(IEnumerable<AuditLogResponse> auditLogResponses, string entityId, DateTime from, DateTime end);
    }
}
