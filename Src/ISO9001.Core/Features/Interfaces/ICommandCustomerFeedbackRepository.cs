using ISO9001.Core.Dtos;

namespace ISO9001.Core.Features.Interfaces;
public interface ICommandCustomerFeedbackRepository
{
    Task RegisterCustomerFeedbackAsync(CustomerFeedbackDto customerFeedbackDto);
    Task SaveChangesAsync();

}
