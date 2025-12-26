namespace ISO9001.Core.Interfaces.CustomerFeedbacks;

public interface IRegisterCustomerFeedbackInputPort
{
    Task HandleAsync(CustomerFeedbackDto customerFeedbackDto);
}
