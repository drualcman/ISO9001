using ISO9001.Entities.Responses;
using ISO9001.GetCustomerFeedbackByRating.BusinessObjects.Interfaces;
using ISO9001.Repositories.CustomerFeedbackRepositories.Entities;
using ISO9001.Repositories.CustomerFeedbackRepositories.Interfaces;

namespace ISO9001.Repositories.CustomerFeedbackRepositories
{
    internal class GetCustomerFeedbackByRatingRepository(IQueryableCustomerFeedbackDataContext dataContext) : IGetCustomerFeedbackByRatingRepository
    {
        public async Task<IEnumerable<CustomerFeedbackResponse>> GetCustomerFeedbackByRatingAsync(string id, int rating, DateTime? from, DateTime? end)
        {

            IQueryable<CustomerFeedbackReadModel> Query = dataContext.CustomerFeedbacks
                .Where(CustomerFeedback => CustomerFeedback.CompanyId == id &&
                CustomerFeedback.Rating == rating &&
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
