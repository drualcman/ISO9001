namespace ISO9001.Core.Repositories.CustomerFeedbackRepositories;

internal class QueryableCustomerFeedbackRepository(IQueryableCustomerFeedbackDataContext dataContext) : IQueryableCustomerFeedbackRepository
{
    public async Task<IEnumerable<CustomerFeedbackResponse>> GetAllCustomerFeedbacksAsync(
        string id, DateTime? from, DateTime? end)
    {
        var CustomerFeedbacks = await dataContext.ToListAsync(
            CustomerFeedback => CustomerFeedback.CompanyId == id &&
                CustomerFeedback.ReportedAt >= from &&
                CustomerFeedback.ReportedAt <= end);

        return CustomerFeedbacks.Select(CustomerFeedback =>
        new CustomerFeedbackResponse(
            CustomerFeedback.EntityId,
            CustomerFeedback.CustomerId,
            CustomerFeedback.Rating,
            CustomerFeedback.ReportedAt));
    }

    public async Task<IEnumerable<CustomerFeedbackResponse>> GetCustomerFeedbackByCustomerIdAsync(
        string id, string customerId, DateTime? from, DateTime? end)
    {
        var CustomerFeedbacks = await dataContext.ToListAsync(
            CustomerFeedback => CustomerFeedback.CompanyId == id &&
            CustomerFeedback.CustomerId == customerId &&
            CustomerFeedback.ReportedAt >= from &&
            CustomerFeedback.ReportedAt <= end);

        return CustomerFeedbacks.Select(CustomerFeedback =>
        new CustomerFeedbackResponse(
            CustomerFeedback.EntityId,
            CustomerFeedback.CustomerId,
            CustomerFeedback.Rating,
            CustomerFeedback.ReportedAt));
    }

    public async Task<IEnumerable<CustomerFeedbackResponse>> GetCustomerFeedbackByEntityId(
        string id, string entityId, DateTime? from, DateTime? end)
    {
        var CustomerFeedbacks = await dataContext.ToListAsync(
            CustomerFeedback => CustomerFeedback.CompanyId == id &&
            CustomerFeedback.EntityId == entityId &&
            CustomerFeedback.ReportedAt >= from &&
            CustomerFeedback.ReportedAt <= end);

        return CustomerFeedbacks.Select(CustomerFeedback =>
        new CustomerFeedbackResponse(
            CustomerFeedback.EntityId,
            CustomerFeedback.CustomerId,
            CustomerFeedback.Rating,
            CustomerFeedback.ReportedAt));
    }

    public async Task<bool> CustomerFeedbackExists(string companyId, int id)
    {
        var CustomerFeedback = await dataContext.ToListAsync(
            CustomerFeedback => CustomerFeedback.CompanyId == companyId &&
            CustomerFeedback.Id == id);

        return CustomerFeedback.Any();
    }

    public async Task<CustomerFeedbackResponse> GetCustomerFeedbackByIdAsync(string companyId, int id)
    {
        var Data = await dataContext.ToListAsync(
            CustomerFeedback => CustomerFeedback.CompanyId == companyId &&
            CustomerFeedback.Id == id);
        var CustomerFeedback = Data.FirstOrDefault();

        if (CustomerFeedback == null)
            return null;

        return new CustomerFeedbackResponse(
            CustomerFeedback.EntityId,
            CustomerFeedback.CustomerId,
            CustomerFeedback.Rating,
            CustomerFeedback.ReportedAt);
    }

    public async Task<IEnumerable<CustomerFeedbackResponse>> GetCustomerFeedbackByRatingAsync(string id, int rating, DateTime? from, DateTime? end)
    {
        var CustomerFeedbacks = await dataContext.ToListAsync(
            CustomerFeedback => CustomerFeedback.CompanyId == id &&
            CustomerFeedback.Rating == rating &&
            CustomerFeedback.ReportedAt >= from &&
            CustomerFeedback.ReportedAt <= end);

        return CustomerFeedbacks.Select(CustomerFeedback =>
        new CustomerFeedbackResponse(
            CustomerFeedback.EntityId,
            CustomerFeedback.CustomerId,
            CustomerFeedback.Rating,
            CustomerFeedback.ReportedAt));

    }
}
