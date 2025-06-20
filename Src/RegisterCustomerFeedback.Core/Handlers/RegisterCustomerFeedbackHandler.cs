using ISO9001.Entities.Dtos;
using ISO9001.RegisterCustomerFeedback.BusinessObjects.Interfaces;

namespace ISO9001.RegisterCustomerFeedback.Core.Handlers
{
    internal class RegisterCustomerFeedbackHandler(
        IRegisterCustomerFeedbackRepository repository) : IRegisterCustomerFeedbackInputPort
    {
        public async Task HandleAsync(CustomerFeedbackDto customerFeedbackDto)
        {
            await repository.RegisterCustomerFeedbackAsync(customerFeedbackDto);
            await repository.SaveChangesAsync();
        }
    }
}
