using System.Linq.Expressions;

namespace ISO9001.Database.InMemory.DataContexts.CustomerFeedbackDataContext;

internal class InMemoryQueryableCustomerFeedbackDataContext(
    InMemoryCustomerFeedbackStore dataContext) : IQueryableCustomerFeedbackDataContext
{
    private IQueryable<CustomerFeedbackReadModel> CustomerFeedbacks =>
        dataContext.CustomerFeedbacks
        .Select(CustomerFeedback => new CustomerFeedbackReadModel
        {
            Id = CustomerFeedback.Id.ToString(),
            EntityId = CustomerFeedback.EntityId,
            CompanyId = CustomerFeedback.CompanyId,
            CustomerId = CustomerFeedback.CustomerId,
            Rating = CustomerFeedback.Rating,
            Comments = CustomerFeedback.Comments,
            ReportedAt = CustomerFeedback.ReportedAt,
            CreatedAt = CustomerFeedback.ReportedAt
        }).AsQueryable();

    public async Task<IEnumerable<CustomerFeedbackReadModel>> ToListAsync(
        Expression<Func<CustomerFeedbackReadModel, bool>> filter = null,
        Func<IQueryable<CustomerFeedbackReadModel>, IOrderedQueryable<CustomerFeedbackReadModel>> orderBy = null)
    {
        IQueryable<CustomerFeedbackReadModel> query = CustomerFeedbacks;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (orderBy != null)
        {
            query = orderBy(query);
        }

        var data = query.ToList();
        return await Task.FromResult(data);
    }
}