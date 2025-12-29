namespace ISO9001.Core.Providers;

internal class CustomerFeedbackEventProvider(IQueryableCustomerFeedbackDataContext context) : IAuditEventProvider
{
    public string EventType => "CustomerFeedback";

    public async Task<IEnumerable<AuditEventResponse>> GetAuditEventsAsync(string entityId, string companyId)
    {
        var data = await context.ToListAsync(CustomerFeedback =>
            CustomerFeedback.EntityId == entityId &&
            CustomerFeedback.CompanyId == companyId,
            CustomerFeedback => CustomerFeedback.OrderBy(CustomerFeedback =>
            CustomerFeedback.ReportedAt));

        return data.Select(CustomerFeedback => new AuditEventResponse(
                CustomerFeedback.Id.ToString(),
                CustomerFeedback.EntityId,
                CustomerFeedback.ReportedAt,
                EventType,
                CustomerFeedback.Comments,
                CustomerFeedback.CustomerId));
    }
}
