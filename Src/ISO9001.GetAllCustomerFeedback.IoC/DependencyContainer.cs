using ISO9001.GetAllCustomerFeedback.Core;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.GetAllCustomerFeedback.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddGetAllCustomerFeedbackServices(this IServiceCollection services)
        {
            services.AddGetAllCustomerFeedbackCoreServices();

            return services;
        }
    }
}
