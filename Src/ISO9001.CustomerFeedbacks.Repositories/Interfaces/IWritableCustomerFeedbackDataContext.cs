using ISO9001.CustomerFeedbacks.Repositories.Entities;

namespace ISO9001.CustomerFeedbacks.Repositories.Interfaces
{
    public interface IWritableCustomerFeedbackDataContext
    {
        Task AddAsync(CustomerFeedback customerFeedback);
        Task SaveChangesAsync();
    }
}
