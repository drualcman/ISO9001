namespace ISO9001.Core.Interfaces.Internals.AuditLog;

internal interface IGenerateAuditLogReportInputPort
{
    ValueTask GenerateAuditLogReportAsync(string companyId, string entityId, DateTime? from, DateTime? end);
}
