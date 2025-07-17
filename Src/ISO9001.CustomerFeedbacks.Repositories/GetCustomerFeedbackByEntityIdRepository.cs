using ISO9001.CustomerFeedbacks.Repositories.Entities;
using ISO9001.CustomerFeedbacks.Repositories.Interfaces;
using ISO9001.Entities.Responses;
using ISO9001.GetCustomerFeedbackByEntityId.BusinessObjects.Interfaces;

namespace ISO9001.CustomerFeedbacks.Repositories
{
    internal class GetCustomerFeedbackByEntityIdRepository
        (IQueryableCustomerFeedbackDataContext dataContext) : IGetCustomerFeedbackByEntityIdRepository
    {
        public async Task<IEnumerable<CustomerFeedbackResponse>> GetCustomerFeedbackByEntityId(string id, string entityId)
        {
            IQueryable<CustomerFeedbackReadModel> Query = 
                dataContext.CustomerFeedbacks.Where(CustomerFeedback => CustomerFeedback.CompanyId == id &&
                CustomerFeedback.EntityId == entityId);

            return await dataContext.ToListAsync(
                Query.Select(CustomerFeedback => new CustomerFeedbackResponse(
                    CustomerFeedback.EntityId,
                    CustomerFeedback.CustomerId,
                    CustomerFeedback.Rating,
                    CustomerFeedback.ReportedAt)));
        }
    }
}
