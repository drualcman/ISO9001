using ISO9001.Entities.Dtos;
using ISO9001.RegisterCustomerFeedback.BusinessObjects.Interfaces;
using ISO9001.RegisterCustomerFeedback.Rest;

namespace ISO9001.WebAPI.Endpoints
{
    public static class CustomerFeedbackEndpoints
    {
        const string EntryPoint = "customer-feedback/";
        public static IEndpointRouteBuilder UserCustomerFeedbackEndpoints(
            this IEndpointRouteBuilder builder)
        {
            builder.MapPost(RegisterCustomerFeedbackEndpoint.RegisterCustomerFeedback.CreateEndpoint(EntryPoint),
                async (CustomerFeedbackDto customerFeedback, IRegisterCustomerFeedbackInputPort inputport) =>
                {
                    await inputport.HandleAsync(customerFeedback);
                    return TypedResults.Created();
                });

            return builder;
        }
    }
}
