using ISO9001.CustomerFeedbacks.Repositories.Entities;
using ISO9001.CustomerFeedbacks.Repositories.Interfaces;
using ISO9001.Entities.Responses;
using ISO9001.GetAllCustomerFeedback.BusinessObjects.Interfaces;

namespace ISO9001.CustomerFeedbacks.Repositories
{
    internal class GetAllCustomerFeedbackRepository(IQueryableCustomerFeedbackDataContext dataContext): IGetAllCustomerFeedbackRepository
    {
        public async Task<IEnumerable<CustomerFeedbackResponse>> GetAllCustomerFeedbacksAsync(
            string id, DateTime? from, DateTime? end)
        {
            IQueryable<CustomerFeedbackReadModel> Query = dataContext.CustomerFeedbacks
                .Where(CustomerFeedback => CustomerFeedback.CompanyId == id &&
                    CustomerFeedback.ReportedAt >= from &&
                    CustomerFeedback.ReportedAt <= end);

            return await dataContext.ToListAsync(
                Query.Select(CustomerFeedback => new CustomerFeedbackResponse(
                    CustomerFeedback.EntityId,
                    CustomerFeedback.CustomerId,
                    CustomerFeedback.Rating,
                    CustomerFeedback.ReportedAt)));
        }
    }
}
