namespace ISO9001.AuditLog.Core.Internals.GenerateAuditLogReport
{
    public interface IGenerateAuditLogReportInputPort
    {
        ValueTask GenerateAuditLogReportAsync(string companyId, string entityId, DateTime? from, DateTime? end);
    }
}
