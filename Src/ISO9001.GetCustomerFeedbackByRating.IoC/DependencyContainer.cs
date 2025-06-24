using ISO9001.GetCustomerFeedbackByRating.Core;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.GetCustomerFeedbackByRating.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddGetCustomerFeedbackByRatingServices(this IServiceCollection services)
        {
            services.AddGetCustomerFeedbackByRatingCoreServices();

            return services;
        }
    }
}
