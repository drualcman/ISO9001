using ISO9001.Entities.Responses;

namespace ISO9001.GetCustomerFeedbackById.BusinessObjects.Interfaces
{
    public interface IGetCustomerFeedbackByIdRepository
    {
        Task<CustomerFeedbackResponse> GetCustomerFeedbackByIdAsync(string companyId, int id);

        Task<bool> CustomerFeedbackExists(string companyId, int id);
    }
}
