using ISO9001.RegisterCustomerFeedback.BusinessObjects.Interfaces;
using ISO9001.RegisterCustomerFeedback.Core.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.RegisterCustomerFeedback.Core
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRegisterCustomerFeedbackCoreServices(
            this IServiceCollection services)
        {
            services.AddScoped<IRegisterCustomerFeedbackInputPort, RegisterCustomerFeedbackHandler>();
            return services;
        }
    }
}
