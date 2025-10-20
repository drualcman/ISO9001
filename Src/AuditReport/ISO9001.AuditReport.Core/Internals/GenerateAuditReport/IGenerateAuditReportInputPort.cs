namespace ISO9001.AuditReport.Core.Internals.GenerateAuditReport
{
    internal interface IGenerateAuditReportInputPort
    {
        ValueTask GenerateAuditReportAsync(string companyId, string entityId, DateTime? from, DateTime? end);
    }
}
