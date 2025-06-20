using ISO9001.Entities.Dtos;

namespace ISO9001.RegisterCustomerFeedback.BusinessObjects.Interfaces
{
    public interface IRegisterCustomerFeedbackInputPort
    {
        Task HandleAsync(CustomerFeedbackDto customerFeedbackDto);
    }
}
