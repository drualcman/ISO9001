using ISO9001.CustomerFeedbacks.Repositories.Entities;
using ISO9001.CustomerFeedbacks.Repositories.Interfaces;

namespace ISO9001.Database.InMemory.DataContexts.CustomerFeedbackDataContext
{
    internal class InMemoryWritableCustomerFeedbackDataContext : IWritableCustomerFeedbackDataContext
    {
        public Task AddAsync(CustomerFeedback customerFeedback)
        {
            var Record = new Entities.CustomerFeedback
            {
                Id = ++InMemoryCustomerFeedbackStore.CurrentId,
                EntityId = customerFeedback.EntityId,
                CompanyId = customerFeedback.CompanyId,
                CustomerId = customerFeedback.CustomerId,
                Rating = customerFeedback.Rating,
                Comments = customerFeedback.Comments,
                ReportedAt = customerFeedback.ReportedAt,
                CreatedAt = DateTime.UtcNow
            };

            InMemoryCustomerFeedbackStore.CustomerFeedbacks.Add(Record);
            return Task.CompletedTask;
        }

        public Task SaveChangesAsync()
        {
            return Task.CompletedTask;
        }
    }
}
