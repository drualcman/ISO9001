namespace ISO9001.Core.Repositories.CustomerFeedbackRepositories;

internal class CommandCustomerFeedbackRepository(
    IWritableCustomerFeedbackDataContext dataContext) : ICommandCustomerFeedbackRepository
{
    public async Task RegisterCustomerFeedbackAsync(CustomerFeedbackDto customerFeedbackDto)
    {
        var NewCustomerFeedback = new CustomerFeedback
        {
            EntityId = customerFeedbackDto.EntityId,
            CompanyId = customerFeedbackDto.CompanyId,
            CustomerId = customerFeedbackDto.CustomerId,
            Rating = customerFeedbackDto.Rating,
            Comments = customerFeedbackDto.Comments,
            ReportedAt = customerFeedbackDto.ReportedAt
        };

        await dataContext.AddAsync(NewCustomerFeedback);
    }

    public async Task SaveChangesAsync()
    {
        await dataContext.SaveChangesAsync();
    }
}
