using ISO9001.Core.Responses;

namespace ISO9001.Core.Features.Interfaces.Internals.CustomerFeedback
{
    public interface IGetCustomerFeedbackByCustomerIdInputPort
    {
        Task<IEnumerable<CustomerFeedbackResponse>> HandleAsync(string id, string customerId, DateTime? from, DateTime? end);
    }
}
