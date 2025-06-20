using ISO9001.RegisterCustomerFeedback.Repositories.Entities;
using ISO9001.RegisterCustomerFeedback.Repositories.Interfaces;

namespace ISO9001.Database.InMemory.DataContexts
{
    internal class InMemoryRegisterCustomerFeedbackDataContext : IRegisterCustomerFeedbackDataContext
    {
        private static readonly List<DataContexts.Entities.CustomerFeedback> customerFeedbackList = new List<DataContexts.Entities.CustomerFeedback>();
        private static int currentId = 0;

        public Task AddAsync(CustomerFeedback customerFeedback)
        {
            var Record = new DataContexts.Entities.CustomerFeedback
            {
                Id = ++currentId,
                EntityId = customerFeedback.EntityId,
                CompanyId = customerFeedback.CompanyId,
                CustomerId = customerFeedback.CustomerId,
                Rating = customerFeedback.Rating,
                Comments = customerFeedback.Comments,
                CreatedAt = DateTime.UtcNow
            };

            customerFeedbackList.Add(Record);
            return Task.CompletedTask;
        }

        public Task SaveChangesAsync()
        {
            return Task.CompletedTask;
        }
    }
}
