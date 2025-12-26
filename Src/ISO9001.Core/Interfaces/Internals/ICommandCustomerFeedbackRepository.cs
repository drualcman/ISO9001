namespace ISO9001.Core.Interfaces.Internals;

internal interface ICommandCustomerFeedbackRepository
{
    Task RegisterCustomerFeedbackAsync(CustomerFeedbackDto customerFeedbackDto);
    Task SaveChangesAsync();

}
