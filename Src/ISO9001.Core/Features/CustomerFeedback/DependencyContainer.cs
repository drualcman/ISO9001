namespace Microsoft.Extensions.DependencyInjection;

public static partial class DependencyContainer
{
    public static IServiceCollection AddCustomerFeedbackCoreServices(
          this IServiceCollection services)
    {
        services.TryAddScoped<ICommandCustomerFeedbackRepository, CommandCustomerFeedbackRepository>();
        services.TryAddScoped<IQueryableCustomerFeedbackRepository, QueryableCustomerFeedbackRepository>();

        services.TryAddScoped<IRegisterCustomerFeedbackInputPort, RegisterCustomerFeedbackHandler>();
        services.TryAddScoped<IGetCustomerFeedbackByRatingInputPort, GetCustomerFeedbackByRatingHandler>();
        services.TryAddScoped<IGetCustomerFeedbackByIdInputPort, GetCustomerFeedbackByIdHandler>();
        services.TryAddScoped<IGetCustomerFeedbackByEntityIdInputPort, GetGustomerFeedbackByEntityIdHandler>();
        services.TryAddScoped<IGetAllCustomerFeedbackInputPort, GetAllCustomerFeedbackHandler>();
        services.TryAddScoped<IGetCustomerFeedbackByCustomerIdInputPort, GetCustomerFeedbackByCustomerIdHandler>();

        services.TryAddScoped<IGenerateCustomerFeedbackController, GenerateCustomerFeedbackReportController>();
        services.TryAddScoped<IGenerateCustomerFeedbackInputPort, GenerateCustomerFeedbackReportHandler>();
        services.TryAddScoped<IGenerateCustomerFeedbackOutputPort, GenerateCustomerFeedbackReportPresenter>();
        return services;
    }

}
