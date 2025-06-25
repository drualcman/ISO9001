using ISO9001.GetCustomerFeedbackByEntityId.Core;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.GetCustomerFeedbackByEntityId.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddGetCustomerFeedbackByEntityIdServices(this  IServiceCollection services)
        {
            services.AddGetCustomerFeedbackByEntityIdCoreServices();

            return services;
        }
    }
}
