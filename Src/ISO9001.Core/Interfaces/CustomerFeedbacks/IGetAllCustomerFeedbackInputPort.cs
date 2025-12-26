namespace ISO9001.Core.Interfaces.CustomerFeedbacks;

public interface IGetAllCustomerFeedbackInputPort
{
    Task<IEnumerable<CustomerFeedbackResponse>> HandleAsync(string id, DateTime? from, DateTime? end);
}
