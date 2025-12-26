namespace ISO9001.Core.Interfaces.CustomerFeedbacks;

public interface ICustomerFeedbackByRatingQuery
{
    Task<IEnumerable<CustomerFeedbackResponse>> HandleAsync(string id, int rating, DateTime? from, DateTime? end);
}
