using ISO9001.Core.Responses;

namespace ISO9001.Core.Features.Interfaces.Internals.CustomerFeedback
{
    public interface IGetCustomerFeedbackByIdInputPort
    {
        Task<CustomerFeedbackResponse> HandleAsync(string companyId, int id);
    }
}
