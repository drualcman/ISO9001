namespace ISO9001.Core.Interfaces.CustomerFeedbacks;

public interface IGetCustomerFeedbackByIdInputPort
{
    Task<CustomerFeedbackResponse> HandleAsync(string companyId, int id);
}
