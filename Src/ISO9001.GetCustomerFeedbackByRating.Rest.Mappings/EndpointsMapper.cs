using ISO9001.GetCustomerFeedbackByRating.BusinessObjects.Interfaces;
using ISO9001.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace ISO9001.GetCustomerFeedbackByRating.Rest.Mappings
{
    public static class EndpointsMapper
    {
        public static IEndpointRouteBuilder UseGetCustomerFeedbackByRatingEndpoint(
            this IEndpointRouteBuilder builder)
        {
            builder.MapGet(("{companyId}/" + GetCustomerFeedbackByRatingEndpoint.Rating + "/{rating}").CreateEndpoint("CustomerFeedbackEndpoints"), async (
                string companyId,
                int rating,
                [FromQuery] DateTime? from,
                [FromQuery] DateTime? end,
                IGetCustomerFeedbackByRatingInputPort inputPort) =>
            {
                var result = await inputPort.HandleAsync(companyId, rating, from, end);
                return TypedResults.Ok(result);

            });

            return builder;

        }
    }

}
