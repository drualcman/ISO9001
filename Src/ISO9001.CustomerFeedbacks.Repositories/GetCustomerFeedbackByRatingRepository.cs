using ISO9001.CustomerFeedbacks.Repositories.Entities;
using ISO9001.CustomerFeedbacks.Repositories.Interfaces;
using ISO9001.Entities.Responses;
using ISO9001.GetCustomerFeedbackByRating.BusinessObjects.Interfaces;

namespace ISO9001.CustomerFeedbacks.Repositories
{
    internal class GetCustomerFeedbackByRatingRepository(IGetCustomerFeedbackByRatingDataContext dataContext) : IGetCustomerFeedbackByRatingRepository
    {
        public async Task<IEnumerable<CustomerFeedbackResponse>> GetCustomerFeedbackByRatingAsync(string id, int rating, DateTime? from, DateTime? end)
        {

            IQueryable<CustomerFeedbackReadModel> Query = dataContext.CustomerFeedbacks
                .Where(CustomerFeedback => CustomerFeedback.CompanyId == id &&
                CustomerFeedback.Rating == rating &&
                CustomerFeedback.ReportedAt >= from &&
                CustomerFeedback.ReportedAt <= end);

            return await dataContext.ToListAsync(Query
                .Select(CustomerFeedback => new CustomerFeedbackResponse(
                    CustomerFeedback.EntityId,
                    CustomerFeedback.CustomerId,
                    CustomerFeedback.Rating,
                    CustomerFeedback.ReportedAt)));

        }
    }
}
