using ISO9001.CustomerFeedbacks.Repositories.Entities;
using ISO9001.CustomerFeedbacks.Repositories.Interfaces;
using ISO9001.Entities.Responses;
using ISO9001.GetCustomerFeedbackByCustomerId.BusinessObjects.Interfaces;

namespace ISO9001.CustomerFeedbacks.Repositories
{
    internal class GetCustomerFeedbackByCustomerIdRepository
        (IQueryableCustomerFeedbackDataContext dataContext): IGetCustomerFeedbackByCustomerIdRepository
    {
        public async Task<IEnumerable<CustomerFeedbackResponse>> GetCustomerFeedbackByCustomerIdAsync
            (string id, string customerId, DateTime? from, DateTime? end)
        {
            IQueryable<CustomerFeedbackReadModel> Query = dataContext.CustomerFeedbacks
                .Where(CustomerFeedback => CustomerFeedback.CompanyId == id &&
                CustomerFeedback.CustomerId == customerId &&
                CustomerFeedback.ReportedAt >= from &&
                CustomerFeedback.ReportedAt <= end);

            var CustomerFeedbacks = await dataContext.ToListAsync(Query);

            return CustomerFeedbacks.Select(CustomerFeedback =>
            new CustomerFeedbackResponse(
                CustomerFeedback.EntityId,
                CustomerFeedback.CustomerId,
                CustomerFeedback.Rating,
                CustomerFeedback.ReportedAt));

        }
    }
}
