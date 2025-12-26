namespace ISO9001.Core.Interfaces.CustomerFeedbacks;

public interface IGetCustomerFeedbackByEntityIdInputPort
{
    Task<IEnumerable<CustomerFeedbackResponse>> HandleAsync(string id, string entityId, DateTime? from, DateTime? end);
}
