namespace ISO9001.Core.Repositories.AuditReport;

internal class QueryableAuditReportRepository(
    IQueryableCustomerFeedbackDataContext customerFeedbackDataContext,
    IQueryableNonConformityDataContext nonConformityDataContext,
    IQueryableIncidentReportDataContext incidentReportDataContext) : IQueryableAuditReportRepository
{
    public async Task<IEnumerable<IncidentReportResponse>> GeAllIncidentReportsOrderByReportedAt(string companyId,
        string entityId, DateTime? from, DateTime? end)
    {
        var IncidentReports = await incidentReportDataContext.ToListAsync(IncidentReport =>
            IncidentReport.CompanyId == companyId &&
            IncidentReport.EntityId == entityId &&
            IncidentReport.ReportedAt >= from &&
            IncidentReport.ReportedAt <= end,
            IncidentReport => IncidentReport.OrderBy(IncidentReport => 
            IncidentReport.ReportedAt));

        return IncidentReports.Select(IncidentReport => new IncidentReportResponse
        (
            IncidentReport.EntityId,
            IncidentReport.ReportedAt,
            IncidentReport.UserId,
            IncidentReport.Description,
            IncidentReport.AffectedProcess,
            IncidentReport.Severity,
            IncidentReport.Data
        ));
    }

    public async Task<IEnumerable<NonConformityMaterResponse>> GeAllNonConformitiessOrderByReportedAt(string companyId,
        string entityId, DateTime? from, DateTime? end)
    {
        var NonConformities = await nonConformityDataContext.ToListAsync(
            nonConformityDataContext.NonConformities
                .Where(NonConformity => NonConformity.CompanyId == companyId &&
                       NonConformity.EntityId == entityId)
                .OrderBy(NonConformity => NonConformity.ReportedAt));

        var MasterIds = NonConformities
            .Select(NonConformity => NonConformity.Id);

        var Details = await nonConformityDataContext.ToListAsync(
            nonConformityDataContext.NonConformityDetails
                .Where(Detail => MasterIds.Contains(Detail.NonConformityId)).OrderBy(Detail => Detail.ReportedAt));

        return NonConformities.Select(NC => new NonConformityMaterResponse
        (
            NC.Id,
            NC.EntityId,
            NC.ReportedAt,
            NC.AffectedProcess,
            NC.Cause,
            NC.Status,
            Details.Count()
            ));
    }


    public async Task<IEnumerable<CustomerFeedbackResponse>> GetAllCustomerFeedbacksOrderByReportedAt(string companyId, string entityId,
        DateTime? from, DateTime? end)
    {

        var CustomerFeedbacks = await customerFeedbackDataContext.ToListAsync(CustomerFeedback => 
            CustomerFeedback.CompanyId == companyId &&
                CustomerFeedback.EntityId == entityId &&
                CustomerFeedback.ReportedAt >= from &&
                CustomerFeedback.ReportedAt <= end,
                CustomerFeedback => CustomerFeedback.OrderBy(CustomerFeedback => 
                CustomerFeedback.ReportedAt));

        return CustomerFeedbacks.Select(CustomerFeedback => new CustomerFeedbackResponse
        (
            CustomerFeedback.EntityId,
            CustomerFeedback.CustomerId,
            CustomerFeedback.Rating,
            CustomerFeedback.ReportedAt
        )).ToList();
    }
}
