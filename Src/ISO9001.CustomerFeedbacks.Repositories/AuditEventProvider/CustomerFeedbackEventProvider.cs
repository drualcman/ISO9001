using ISO9001.CustomerFeedbacks.Repositories.Interfaces;
using ISO9001.Entities.Responses;
using ISO9001.Interfaces.Interfaces;

namespace ISO9001.CustomerFeedbacks.Repositories.AuditEventProvider
{
    internal class CustomerFeedbackEventProvider(IQueryableCustomerFeedbackDataContext context) : IAuditEventProvider
    {
        public string EventType => "CustomerFeedback";

        public async Task<IEnumerable<AuditEventResponse>> GetAuditEventsAsync(string entityId, string companyId)
        {
            var CustomerFeedbacks = context.CustomerFeedbacks.Where
                (CustomerFeedback => CustomerFeedback.EntityId == entityId &&
                CustomerFeedback.CompanyId == companyId)
                .OrderBy(CustomerFeedback => CustomerFeedback.Id)
                .Select(CustomerFeedback => new AuditEventResponse(
                    CustomerFeedback.Id.ToString(),
                    CustomerFeedback.EntityId,
                    CustomerFeedback.ReportedAt,
                    EventType,
                    CustomerFeedback.Comments,
                    CustomerFeedback.CustomerId));

            return await Task.FromResult(CustomerFeedbacks);
        }
    }
}
