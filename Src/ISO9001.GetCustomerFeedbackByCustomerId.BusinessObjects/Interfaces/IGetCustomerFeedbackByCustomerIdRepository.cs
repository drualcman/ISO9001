using ISO9001.Entities.Responses;

namespace ISO9001.GetCustomerFeedbackByCustomerId.BusinessObjects.Interfaces
{
    public interface IGetCustomerFeedbackByCustomerIdRepository
    {
        Task<IEnumerable<CustomerFeedbackResponse>> GetCustomerFeedbackByCustomerIdAsync(string id, string customerId, DateTime? from, DateTime? end);
    }
}
