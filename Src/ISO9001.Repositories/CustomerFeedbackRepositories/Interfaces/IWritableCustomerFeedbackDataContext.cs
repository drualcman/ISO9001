using ISO9001.Repositories.CustomerFeedbackRepositories.Entities;

namespace ISO9001.Repositories.CustomerFeedbackRepositories.Interfaces
{
    public interface IWritableCustomerFeedbackDataContext
    {
        Task AddAsync(CustomerFeedback customerFeedback);
        Task SaveChangesAsync();
    }
}
