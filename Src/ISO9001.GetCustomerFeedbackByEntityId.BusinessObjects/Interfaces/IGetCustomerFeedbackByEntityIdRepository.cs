using ISO9001.Entities.Responses;

namespace ISO9001.GetCustomerFeedbackByEntityId.BusinessObjects.Interfaces
{
    public interface IGetCustomerFeedbackByEntityIdRepository
    {
        Task<IEnumerable<CustomerFeedbackResponse>> GetCustomerFeedbackByEntityId(string id, string entityId);
    }
}
