namespace ISO9001.Core.Features.Interfaces.Internals.AuditReport;

internal interface IGenerateAuditReportInputPort
{
    ValueTask GenerateAuditReportAsync(string companyId, string entityId, DateTime? from, DateTime? end);
}
