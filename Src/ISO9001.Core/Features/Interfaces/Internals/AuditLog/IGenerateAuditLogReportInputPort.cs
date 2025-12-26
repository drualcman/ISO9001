namespace ISO9001.Core.Features.Interfaces.Internals.AuditLog
{
    public interface IGenerateAuditLogReportInputPort
    {
        ValueTask GenerateAuditLogReportAsync(string companyId, string entityId, DateTime? from, DateTime? end);
    }
}
