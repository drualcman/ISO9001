using ISO9001.GetCustomerFeedbackById.BusinessObjects.Interfaces;
using ISO9001.GetCustomerFeedbackById.Core.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.GetCustomerFeedbackById.Core
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddGetCustomerFeedbackByIdCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IGetCustomerFeedbackByIdInputPort, GetCustomerFeedbackByIdHandler>();

            return services;
        }
    }

}
