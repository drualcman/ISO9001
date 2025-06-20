using ISO9001.RegisterCustomerFeedback.Core;
using ISO9001.RegisterCustomerFeedback.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.RegisterCustomerFeedback.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRegisterCustomerFeedbackServices(
            this IServiceCollection services)
        {
            services.AddRegisterCustomerFeedbackCoreServices();
            services.AddRegisterCustomerFeedbackRepositoryService();
            return services;
        }
    }
}
