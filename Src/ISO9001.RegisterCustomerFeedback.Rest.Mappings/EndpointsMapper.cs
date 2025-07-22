using ISO9001.Entities.Dtos;
using ISO9001.Entities.Requests;
using ISO9001.Helpers;
using ISO9001.RegisterCustomerFeedback.BusinessObjects.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace ISO9001.RegisterCustomerFeedback.Rest.Mappings
{
    public static class EndpointsMapper
    {
        public static IEndpointRouteBuilder UseRegisterCustomerFeedbackEndpoint(
            this IEndpointRouteBuilder builder)
        {
            builder.MapPost("".CreateEndpoint("CustomerFeedbackEndpoints"),
                async (CustomerFeedbackRequest customerFeedback, IRegisterCustomerFeedbackInputPort inputport) =>
                {
                    await inputport.HandleAsync(new CustomerFeedbackDto(
                        customerFeedback.EntityId,
                        customerFeedback.CompanyId,
                        customerFeedback.CustomerId,
                        customerFeedback.Rating,
                        customerFeedback.Comments,
                        customerFeedback.ReportedAt
                        ));
                    return TypedResults.Created();
                });
            return builder;
        }
    }

}
