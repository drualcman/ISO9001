using ISO9001.CustomerFeedbacks.Repositories.Entities;

namespace ISO9001.CustomerFeedbacks.Repositories.Interfaces
{
    public interface IQueryableCustomerFeedbackDataContext
    {
        IQueryable<CustomerFeedbackReadModel> CustomerFeedbacks { get; }
        Task<IEnumerable<ReturnType>> ToListAsync<ReturnType>(
            IQueryable<ReturnType> queryable);
    }
}
