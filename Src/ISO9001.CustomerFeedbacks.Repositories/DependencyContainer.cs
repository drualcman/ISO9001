﻿using ISO9001.GetAllCustomerFeedback.BusinessObjects.Interfaces;
using ISO9001.GetCustomerFeedbackByCustomerId.BusinessObjects.Interfaces;
using ISO9001.GetCustomerFeedbackByEntityId.BusinessObjects.Interfaces;
using ISO9001.GetCustomerFeedbackByRating.BusinessObjects.Interfaces;
using ISO9001.RegisterCustomerFeedback.BusinessObjects.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.CustomerFeedbacks.Repositories
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddCustomerFeedbacksRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<IRegisterCustomerFeedbackRepository, RegisterCustomerFeedbackRepository>();
            services.AddScoped<IGetAllCustomerFeedbackRepository, GetAllCustomerFeedbackRepository>();
            services.AddScoped<IGetCustomerFeedbackByEntityIdRepository, GetCustomerFeedbackByEntityIdRepository>();
            services.AddScoped<IGetCustomerFeedbackByCustomerIdRepository, GetCustomerFeedbackByCustomerIdRepository>();
            services.AddScoped<IGetCustomerFeedbackByRatingRepository, GetCustomerFeedbackByRatingRepository>();

            return services;
        }
    }
}
