namespace ISO9001.AuditLog.Core.Internals.GenerateAuditLogReport
{
    public interface IGenerateAuditLogReportInputPort
    {
        ValueTask GenerateAuditReportAsync(string companyId, string entityId, DateTime? from, DateTime? end);
    }
}
