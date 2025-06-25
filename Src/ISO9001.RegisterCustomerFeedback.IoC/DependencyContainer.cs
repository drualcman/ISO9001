using ISO9001.RegisterCustomerFeedback.Core;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.RegisterCustomerFeedback.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRegisterCustomerFeedbackServices(
            this IServiceCollection services)
        {
            services.AddRegisterCustomerFeedbackCoreServices();
            return services;
        }
    }
}
