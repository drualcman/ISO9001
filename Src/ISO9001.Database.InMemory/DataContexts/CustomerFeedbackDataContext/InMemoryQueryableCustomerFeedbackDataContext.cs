namespace ISO9001.Database.InMemory.DataContexts.CustomerFeedbackDataContext
{
    internal class InMemoryQueryableCustomerFeedbackDataContext(
        InMemoryCustomerFeedbackStore dataContext) : IQueryableCustomerFeedbackDataContext
    {
        public IQueryable<CustomerFeedbackReadModel> CustomerFeedbacks =>
            dataContext.CustomerFeedbacks
            .Select(CustomerFeedback => new CustomerFeedbackReadModel
            {
                Id = CustomerFeedback.Id,
                EntityId = CustomerFeedback.EntityId,
                CompanyId = CustomerFeedback.CompanyId,
                CustomerId = CustomerFeedback.CustomerId,
                Rating = CustomerFeedback.Rating,
                Comments = CustomerFeedback.Comments,
                ReportedAt = CustomerFeedback.ReportedAt,
                CreatedAt = CustomerFeedback.ReportedAt
            }).AsQueryable();


        public async Task<IEnumerable<CustomerFeedbackReadModel>> ToListAsync(IQueryable<CustomerFeedbackReadModel> queryable)
            => await Task.FromResult(queryable.ToList());

    }
}

