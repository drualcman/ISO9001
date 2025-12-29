namespace ISO9001.Core.Interfaces.CustomerFeedbacks;

public interface ICustomerFeedbackByIdQuery
{
    Task<CustomerFeedbackResponse> HandleAsync(string companyId, string id);
}
