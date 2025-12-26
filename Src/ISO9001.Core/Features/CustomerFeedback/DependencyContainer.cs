namespace Microsoft.Extensions.DependencyInjection;

public static partial class DependencyContainer
{
    public static IServiceCollection AddCustomerFeedbackCoreServices(
          this IServiceCollection services)
    {
        services.TryAddScoped<ICommandCustomerFeedbackRepository, CommandCustomerFeedbackRepository>();
        services.TryAddScoped<IQueryableCustomerFeedbackRepository, QueryableCustomerFeedbackRepository>();

        services.TryAddScoped<IRegisterCustomerFeedback, RegisterCustomerFeedbackHandler>();
        services.TryAddScoped<ICustomerFeedbackByRatingQuery, GetCustomerFeedbackByRatingHandler>();
        services.TryAddScoped<ICustomerFeedbackByIdQuery, GetCustomerFeedbackByIdHandler>();
        services.TryAddScoped<ICustomerFeedbackByEntityIdQuery, GetGustomerFeedbackByEntityIdHandler>();
        services.TryAddScoped<IAllCustomerFeedbackQuery, GetAllCustomerFeedbackHandler>();
        services.TryAddScoped<ICustomerFeedbackByCustomerIdQuery, GetCustomerFeedbackByCustomerIdHandler>();

        services.TryAddScoped<IGenerateCustomerFeedbackReport, GenerateCustomerFeedbackReportController>();
        services.TryAddScoped<IGenerateCustomerFeedbackInputPort, GenerateCustomerFeedbackReportHandler>();
        services.TryAddScoped<IGenerateCustomerFeedbackOutputPort, GenerateCustomerFeedbackReportPresenter>();
        return services;
    }

}
