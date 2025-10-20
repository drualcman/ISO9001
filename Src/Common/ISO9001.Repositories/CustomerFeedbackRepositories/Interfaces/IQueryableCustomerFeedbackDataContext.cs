namespace ISO9001.Repositories.CustomerFeedbackRepositories.Interfaces
{
    public interface IQueryableCustomerFeedbackDataContext
    {
        IQueryable<CustomerFeedbackReadModel> CustomerFeedbacks { get; }
        Task<IEnumerable<CustomerFeedbackReadModel>> ToListAsync(
            IQueryable<CustomerFeedbackReadModel> queryable);
    }
}
