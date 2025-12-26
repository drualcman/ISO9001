namespace ISO9001.Core.Interfaces.CustomerFeedbacks;

public interface IAllCustomerFeedbackQuery
{
    Task<IEnumerable<CustomerFeedbackResponse>> HandleAsync(string id, DateTime? from, DateTime? end);
}
