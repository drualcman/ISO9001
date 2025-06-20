using ISO9001.RegisterCustomerFeedback.Repositories.Entities;

namespace ISO9001.RegisterCustomerFeedback.Repositories.Interfaces
{
    public interface IRegisterCustomerFeedbackDataContext
    {
        Task AddAsync(CustomerFeedback customerFeedback);
        Task SaveChangesAsync();

    }
}
