using ISO9001.GetCustomerFeedbackById.BusinessObjects.Interfaces;
using ISO9001.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace ISO9001.GetCustomerFeedbackById.Mappings
{
    public static class EndpointsMapper
    {
        public static IEndpointRouteBuilder MapGetCustomerFeedbackByIdEndpoint(
            this IEndpointRouteBuilder builder)
        {
            builder.MapGet(("{companyId}/" + GetCustomerFeedbackByIdEndpoint.Id + "/{id}").CreateEndpoint("CustomerFeedbackEndpoints"), async (
                string companyId,
                int id,
                IGetCustomerFeedbackByIdInputPort inputport) =>
            {
                var Result = await inputport.HandleAsync(companyId, id);
                return TypedResults.Ok(Result);
            }
            );
            return builder;
        }
    }

}
