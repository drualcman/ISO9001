using ISO9001.GetCustomerFeedbackById.Core;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.GetCustomerFeedbackById.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddGetCustomerFeedbackByIdServices(this IServiceCollection services)
        {
            services.AddGetCustomerFeedbackByIdCoreServices();

            return services;
        }
    }

}
