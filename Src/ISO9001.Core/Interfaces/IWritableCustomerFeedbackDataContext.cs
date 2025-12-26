namespace ISO9001.Core.Interfaces;

public interface IWritableCustomerFeedbackDataContext
{
    Task AddAsync(CustomerFeedback customerFeedback);
    Task SaveChangesAsync();
}
