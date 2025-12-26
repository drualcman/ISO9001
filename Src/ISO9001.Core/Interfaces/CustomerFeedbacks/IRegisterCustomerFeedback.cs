namespace ISO9001.Core.Interfaces.CustomerFeedbacks;

public interface IRegisterCustomerFeedback
{
    Task HandleAsync(CustomerFeedbackDto customerFeedbackDto);
}
