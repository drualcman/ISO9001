using ISO9001.Entities.Dtos;
using ISO9001.RegisterCustomerFeedback.BusinessObjects.Interfaces;
using ISO9001.RegisterCustomerFeedback.Repositories.Entities;
using ISO9001.RegisterCustomerFeedback.Repositories.Interfaces;

namespace ISO9001.RegisterCustomerFeedback.Repositories
{
    internal class RegisterCustomerFeedbackRepository(
        IRegisterCustomerFeedbackDataContext dataContext) : IRegisterCustomerFeedbackRepository
    {
        public async Task RegisterCustomerFeedbackAsync(CustomerFeedbackDto customerFeedbackDto)
        {
            var NewCustomerFeedback = new CustomerFeedback
            {
                EntityId = customerFeedbackDto.EntityId,
                CompanyId = customerFeedbackDto.CompanyId,
                CustomerId = customerFeedbackDto.CustomerId,
                Rating = customerFeedbackDto.Rating,
                Comments = customerFeedbackDto.Comments
            };

            await dataContext.AddAsync(NewCustomerFeedback);
        }

        public async Task SaveChangesAsync()
        {
            await dataContext.SaveChangesAsync();
        }
    }
}
