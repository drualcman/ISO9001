using ISO9001.Core.Responses;

namespace ISO9001.Core.Features.Interfaces.Internals.CustomerFeedback
{
    public interface IGetCustomerFeedbackByEntityIdInputPort
    {
        Task<IEnumerable<CustomerFeedbackResponse>> HandleAsync(string id, string entityId, DateTime? from, DateTime? end);
    }
}
