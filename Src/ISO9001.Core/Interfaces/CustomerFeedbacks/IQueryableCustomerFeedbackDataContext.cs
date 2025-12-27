namespace ISO9001.Core.Interfaces.CustomerFeedbacks;

public interface IQueryableCustomerFeedbackDataContext
{
    Task<IEnumerable<CustomerFeedbackReadModel>> ToListAsync(
        Expression<Func<CustomerFeedbackReadModel, bool>> filter = null,
        Func<IQueryable<CustomerFeedbackReadModel>, IOrderedQueryable<CustomerFeedbackReadModel>> orderBy = null);
}
