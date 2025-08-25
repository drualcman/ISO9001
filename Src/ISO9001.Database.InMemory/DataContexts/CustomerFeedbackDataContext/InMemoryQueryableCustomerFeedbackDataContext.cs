using ISO9001.Repositories.CustomerFeedbackRepositories.Entities;
using ISO9001.Repositories.CustomerFeedbackRepositories.Interfaces;

namespace ISO9001.Database.InMemory.DataContexts.CustomerFeedbackDataContext
{
    internal class InMemoryQueryableCustomerFeedbackDataContext : IQueryableCustomerFeedbackDataContext
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


        public async Task<IEnumerable<CustomerFeedbackReadModel>> ToListAsync(IQueryable<CustomerFeedbackReadModel> queryable)
            => await Task.FromResult(queryable.ToList());

    }
}

