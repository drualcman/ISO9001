namespace ISO9001.AuditReport.Core.Internals.GenerateAuditReport
{
    public interface IGenerateAuditReportController
    {
        Task<byte[]> HandleAsync(string companyId, string entityId, DateTime? from, DateTime? end);
    }
}
