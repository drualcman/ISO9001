using ISO9001.Entities.Responses;

namespace ISO9001.GetAllCustomerFeedback.BusinessObjects.Interfaces
{
    public interface IGetAllCustomerFeedbackInputPort
    {
        Task<IEnumerable<CustomerFeedbackResponse>> HandleAsync(string id, DateTime? from, DateTime? end);
    }
}
