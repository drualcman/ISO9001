using ISO9001.GetCustomerFeedbackByRating.BusinessObjects.Interfaces;
using ISO9001.GetCustomerFeedbackByRating.Core.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.GetCustomerFeedbackByRating.Core
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddGetCustomerFeedbackByRatingCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IGetCustomerFeedbackByRatingInputPort, GetCustomerFeedbackByRatingHandler>();
            return services;
        }
    }
}
