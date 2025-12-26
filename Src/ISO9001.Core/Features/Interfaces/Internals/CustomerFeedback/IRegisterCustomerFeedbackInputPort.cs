using ISO9001.Core.Dtos;

namespace ISO9001.Core.Features.Interfaces.Internals.CustomerFeedback
{
    public interface IRegisterCustomerFeedbackInputPort
    {
        Task HandleAsync(CustomerFeedbackDto customerFeedbackDto);
    }
}
