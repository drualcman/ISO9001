namespace Microsoft.Extensions.DependencyInjection;

public static partial class DependencyContainer
{
    public static IServiceCollection AddCustomerFeedbackCoreServices(
          this IServiceCollection services)
    {
        services.AddScoped<IRegisterCustomerFeedbackInputPort, RegisterCustomerFeedbackHandler>();
        services.AddScoped<IGetCustomerFeedbackByRatingInputPort, GetCustomerFeedbackByRatingHandler>();
        services.AddScoped<IGetCustomerFeedbackByIdInputPort, GetCustomerFeedbackByIdHandler>();
        services.AddScoped<IGetCustomerFeedbackByEntityIdInputPort, GetGustomerFeedbackByEntityIdHandler>();
        services.AddScoped<IGetAllCustomerFeedbackInputPort, GetAllCustomerFeedbackHandler>();
        services.AddScoped<IGetCustomerFeedbackByCustomerIdInputPort, GetCustomerFeedbackByCustomerIdHandler>();

        services.AddScoped<IGenerateCustomerFeedbackController, GenerateCustomerFeedbackReportController>();
        services.AddScoped<IGenerateCustomerFeedbackInputPort, GenerateCustomerFeedbackReportHandler>();
        services.AddScoped<IGenerateCustomerFeedbackOutputPort, GenerateCustomerFeedbackReportPresenter>();
        return services;
    }

}
