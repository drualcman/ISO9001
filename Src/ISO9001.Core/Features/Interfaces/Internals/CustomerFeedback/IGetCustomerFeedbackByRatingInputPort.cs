using ISO9001.Core.Responses;

namespace ISO9001.Core.Features.Interfaces.Internals.CustomerFeedback
{
    public interface IGetCustomerFeedbackByRatingInputPort
    {
        Task<IEnumerable<CustomerFeedbackResponse>> HandleAsync(string id, int rating, DateTime? from, DateTime? end);
    }
}
