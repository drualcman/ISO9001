namespace ISO9001.Core.Interfaces.CustomerFeedbacks;

public interface IGetCustomerFeedbackByRatingInputPort
{
    Task<IEnumerable<CustomerFeedbackResponse>> HandleAsync(string id, int rating, DateTime? from, DateTime? end);
}
