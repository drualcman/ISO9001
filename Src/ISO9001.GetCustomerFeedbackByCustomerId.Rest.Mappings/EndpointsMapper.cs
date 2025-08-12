using ISO9001.GetCustomerFeedbackByCustomerId.BusinessObjects.Interfaces;
using ISO9001.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace ISO9001.GetCustomerFeedbackByCustomerId.Rest.Mappings
{
    public static class EndpointsMapper
    {
        public static IEndpointRouteBuilder MapGetCustomerFeedbackByCustomerIdEndpoint(
            this IEndpointRouteBuilder builder)
        {
            builder.MapGet(("{companyId}/" + GetCustomerFeedbackByCustomerIdEndpoint.Customer + "/{customerId}").CreateEndpoint("CustomerFeedbackEndpoints"), async (
                string companyId,
                string customerId,
                [FromQuery] DateTime? from,
                [FromQuery] DateTime? end,
                IGetCustomerFeedbackByCustomerIdInputPort inputPort) =>
            {
                var result = await inputPort.HandleAsync(companyId, customerId, from, end);
                return TypedResults.Ok(result);

            });

            return builder;
        }
    }

}
