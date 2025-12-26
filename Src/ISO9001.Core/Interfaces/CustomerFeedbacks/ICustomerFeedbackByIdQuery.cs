namespace ISO9001.Core.Interfaces.CustomerFeedbacks;

public interface ICustomerFeedbackByIdQuery
{
    Task<CustomerFeedbackResponse> HandleAsync(string companyId, int id);
}
