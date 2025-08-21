using ISO9001.Entities.Responses;
using ISO9001.GetCustomerFeedbackById.BusinessObjects.Interfaces;
using ISO9001.Repositories.CustomerFeedbackRepositories.Interfaces;

namespace ISO9001.Repositories.CustomerFeedbackRepositories
{
    internal class GetCustomerFeedbackByIdRepository(
        IQueryableCustomerFeedbackDataContext dataContext): IGetCustomerFeedbackByIdRepository
    {
        public Task<bool> CustomerFeedbackExists(string companyId, int id)
        {
            var CustomerFeedback = dataContext.CustomerFeedbacks
                .FirstOrDefault(CustomerFeedback => CustomerFeedback.CompanyId == companyId &&
                CustomerFeedback.Id == id);

            return Task.FromResult(CustomerFeedback != null);    
        }

        public Task<CustomerFeedbackResponse> GetCustomerFeedbackByIdAsync(string companyId, int id)
        {
            var CustomerFeedback = dataContext.CustomerFeedbacks
                .FirstOrDefault(CustomerFeedback => CustomerFeedback.CompanyId == companyId &&
                CustomerFeedback.Id == id);

            return Task.FromResult(new CustomerFeedbackResponse(
                CustomerFeedback.EntityId,
                CustomerFeedback.CustomerId,
                CustomerFeedback.Rating,
                CustomerFeedback.ReportedAt));
        }
    }
}
