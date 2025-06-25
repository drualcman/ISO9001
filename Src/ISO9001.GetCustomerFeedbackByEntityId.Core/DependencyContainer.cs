using ISO9001.GetCustomerFeedbackByEntityId.BusinessObjects.Interfaces;
using ISO9001.GetCustomerFeedbackByEntityId.Core.Handler;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.GetCustomerFeedbackByEntityId.Core
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddGetCustomerFeedbackByEntityIdCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IGetCustomerFeedbackByEntityIdInputPort, GetGustomerFeedbackByEntityIdHandler>();
            return services;
        }
    }
}
