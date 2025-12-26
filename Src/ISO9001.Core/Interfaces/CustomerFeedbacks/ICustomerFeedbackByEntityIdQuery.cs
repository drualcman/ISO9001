namespace ISO9001.Core.Interfaces.CustomerFeedbacks;

public interface ICustomerFeedbackByEntityIdQuery
{
    Task<IEnumerable<CustomerFeedbackResponse>> HandleAsync(string id, string entityId, DateTime? from, DateTime? end);
}
