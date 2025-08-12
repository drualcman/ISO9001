using ISO9001.Entities.Responses;

namespace ISO9001.GetCustomerFeedbackById.BusinessObjects.Interfaces
{
    public interface IGetCustomerFeedbackByIdInputPort
    {
        Task<CustomerFeedbackResponse> HandleAsync(string companyId, int id);
    }
}
