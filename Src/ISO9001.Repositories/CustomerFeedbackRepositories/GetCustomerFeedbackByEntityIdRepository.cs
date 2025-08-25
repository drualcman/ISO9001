using ISO9001.Entities.Responses;
using ISO9001.GetCustomerFeedbackByEntityId.BusinessObjects.Interfaces;
using ISO9001.Repositories.CustomerFeedbackRepositories.Entities;
using ISO9001.Repositories.CustomerFeedbackRepositories.Interfaces;

namespace ISO9001.Repositories.CustomerFeedbackRepositories
{
    internal class GetCustomerFeedbackByEntityIdRepository
        (IQueryableCustomerFeedbackDataContext dataContext) : IGetCustomerFeedbackByEntityIdRepository
    {
        public async Task<IEnumerable<CustomerFeedbackResponse>> GetCustomerFeedbackByEntityId(string id, string entityId)
        {
            IQueryable<CustomerFeedbackReadModel> Query = 
                dataContext.CustomerFeedbacks.Where(CustomerFeedback => CustomerFeedback.CompanyId == id &&
                CustomerFeedback.EntityId == entityId);

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
