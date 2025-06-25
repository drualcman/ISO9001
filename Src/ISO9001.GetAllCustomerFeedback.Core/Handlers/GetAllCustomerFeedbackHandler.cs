using ISO9001.Entities.Responses;
using ISO9001.GetAllCustomerFeedback.BusinessObjects.Interfaces;

namespace ISO9001.GetAllCustomerFeedback.Core.Handlers
{
    internal class GetAllCustomerFeedbackHandler(
        IGetAllCustomerFeedbackRepository repository) : IGetAllCustomerFeedbackInputPort
    {
        public async Task<IEnumerable<CustomerFeedbackResponse>> HandleAsync(string id, DateTime? from, DateTime? end)
        {
            DateTime UtcFrom = from != null ? from.Value.Date
                : DateTime.UtcNow.Date.AddDays(-30);

            DateTime UtcEnd = end != null ? end.Value.Date.AddDays(1).AddTicks(-1)
                : DateTime.UtcNow.Date.AddDays(1).AddTicks(-1);

            return await repository.GetAllCustomerFeedbacksAsync(id, UtcFrom, UtcEnd);


        }
    }
}
