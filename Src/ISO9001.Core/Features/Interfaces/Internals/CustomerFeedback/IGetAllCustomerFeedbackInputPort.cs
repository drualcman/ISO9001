using ISO9001.Core.Responses;

namespace ISO9001.Core.Features.Interfaces.Internals.CustomerFeedback
{
    public interface IGetAllCustomerFeedbackInputPort
    {
        Task<IEnumerable<CustomerFeedbackResponse>> HandleAsync(string id, DateTime? from, DateTime? end);
    }
}
