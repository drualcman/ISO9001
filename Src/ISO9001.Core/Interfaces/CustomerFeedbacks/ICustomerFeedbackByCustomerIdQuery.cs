namespace ISO9001.Core.Interfaces.CustomerFeedbacks;

public interface ICustomerFeedbackByCustomerIdQuery
{
    Task<IEnumerable<CustomerFeedbackResponse>> HandleAsync(string id, string customerId, DateTime? from, DateTime? end);
}
