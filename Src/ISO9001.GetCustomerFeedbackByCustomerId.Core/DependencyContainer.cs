using ISO9001.GetCustomerFeedbackByCustomerId.BusinessObjects.Interfaces;
using ISO9001.GetCustomerFeedbackByCustomerId.Core.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.GetCustomerFeedbackByCustomerId.Core
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddGetCustomerFeedbackByCustomerIdCoreServices(
            this IServiceCollection services)
        {
            services.AddScoped<IGetCustomerFeedbackByCustomerIdInputPort, GetCustomerFeedbackByCustomerIdHandler>();

            return services;
        }
    }
}
