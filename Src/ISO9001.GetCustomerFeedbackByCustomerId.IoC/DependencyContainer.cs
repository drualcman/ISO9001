using ISO9001.GetCustomerFeedbackByCustomerId.Core;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.GetCustomerFeedbackByCustomerId.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddGetCustomerFeedbackByCustomerIdServices(this IServiceCollection services)
        {
            services.AddGetCustomerFeedbackByCustomerIdCoreServices();
            return services;
        }
    }
}
