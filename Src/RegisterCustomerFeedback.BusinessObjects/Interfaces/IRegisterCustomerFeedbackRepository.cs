using ISO9001.Entities.Dtos;

namespace ISO9001.RegisterCustomerFeedback.BusinessObjects.Interfaces
{
    public interface IRegisterCustomerFeedbackRepository
    {
        Task RegisterCustomerFeedbackAsync(CustomerFeedbackDto customerFeedbackDto);
        Task SaveChangesAsync();
    }
}
