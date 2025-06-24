using ISO9001.CustomerFeedbacks.Repositories.Entities;
using ISO9001.CustomerFeedbacks.Repositories.Interfaces;

namespace ISO9001.Database.InMemory.DataContexts.CustomerFeedbackDataContext
{
    internal class InMemoryGetAllCustomerFeedbackDataContext : IGetAllCustomerFeedbackDataContext
    {
        public IQueryable<CustomerFeedbackReadModel> CustomerFeedbacks => 
            InMemoryCustomerFeedbackStore.CustomerFeedbacks
            .Select(CustomerFeedback => new CustomerFeedbackReadModel
            {
                Id = CustomerFeedback.Id,
                EntityId = CustomerFeedback.EntityId,
                CompanyId = CustomerFeedback.CompanyId,
                CustomerId = CustomerFeedback.CustomerId,
                Rating = CustomerFeedback.Rating,
                Comments = CustomerFeedback.Comments,
                ReportedAt = CustomerFeedback.ReportedAt,
                CreatedAt = CustomerFeedback.ReportedAt
            }).AsQueryable();

        public async Task<IEnumerable<ReturnType>> ToListAsync<ReturnType>(IQueryable<ReturnType> queryable)
            => await Task.FromResult(queryable.ToList());
    }
}
