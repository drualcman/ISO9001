namespace ISO9001.Core.Interfaces.Internals;

internal interface IQueryableCustomerFeedbackRepository
{
    Task<IEnumerable<CustomerFeedbackResponse>> GetCustomerFeedbackByRatingAsync(string id, int rating, DateTime? from, DateTime? end);

    Task<CustomerFeedbackResponse> GetCustomerFeedbackByIdAsync(string companyId, string id);

    Task<bool> CustomerFeedbackExists(string companyId, string id);

    Task<IEnumerable<CustomerFeedbackResponse>> GetCustomerFeedbackByEntityId(string id, string entityId, DateTime? from, DateTime? end);

    Task<IEnumerable<CustomerFeedbackResponse>> GetCustomerFeedbackByCustomerIdAsync(string id, string customerId, DateTime? from, DateTime? end);

    Task<IEnumerable<CustomerFeedbackResponse>> GetAllCustomerFeedbacksAsync(string id, DateTime? from, DateTime? end);
}
