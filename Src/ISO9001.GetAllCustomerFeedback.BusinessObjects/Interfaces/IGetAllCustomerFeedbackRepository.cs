using ISO9001.Entities.Responses;

namespace ISO9001.GetAllCustomerFeedback.BusinessObjects.Interfaces
{
    public interface IGetAllCustomerFeedbackRepository
    {
        Task<IEnumerable<CustomerFeedbackResponse>> GetAllCustomerFeedbacksAsync(string id, DateTime? from, DateTime? end);
    }
}
