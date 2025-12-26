namespace ISO9001.Core.Interfaces.CustomerFeedbacks;

public interface IWritableCustomerFeedbackDataContext
{
    Task AddAsync(CustomerFeedback customerFeedback);
    Task SaveChangesAsync();
}
