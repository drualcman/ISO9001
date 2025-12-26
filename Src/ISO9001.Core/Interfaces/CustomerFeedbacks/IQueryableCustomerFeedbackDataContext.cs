namespace ISO9001.Core.Interfaces.CustomerFeedbacks;

public interface IQueryableCustomerFeedbackDataContext
{
    IQueryable<CustomerFeedbackReadModel> CustomerFeedbacks { get; }
    Task<IEnumerable<CustomerFeedbackReadModel>> ToListAsync(
        IQueryable<CustomerFeedbackReadModel> queryable);
}
