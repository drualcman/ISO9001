using ISO9001.RegisterCustomerFeedback.BusinessObjects.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.RegisterCustomerFeedback.Repositories
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRegisterCustomerFeedbackRepositoryService(
            this IServiceCollection services)
        {
            services.AddScoped<IRegisterCustomerFeedbackRepository, RegisterCustomerFeedbackRepository>();

            return services;
        }
    }
}
