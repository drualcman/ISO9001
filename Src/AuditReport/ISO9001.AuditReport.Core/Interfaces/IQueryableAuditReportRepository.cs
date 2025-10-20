namespace ISO9001.AuditReport.Core.Interfaces
{
    public interface IQueryableAuditReportRepository
    {
        Task<IEnumerable<NonConformityMaterResponse>> GeAllNonConformitiessOrderByReportedAt(string companyId, string entityId, DateTime? from, DateTime? end);
        Task<IEnumerable<IncidentReportResponse>> GeAllIncidentReportsOrderByReportedAt(string companyId, string entityId, DateTime? from, DateTime? end);
        Task<IEnumerable<CustomerFeedbackResponse>> GetAllCustomerFeedbacksOrderByReportedAt(string companyId, string entityId, DateTime? from, DateTime? end);
    }
}
