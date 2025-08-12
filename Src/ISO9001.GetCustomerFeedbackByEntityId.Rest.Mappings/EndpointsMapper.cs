using ISO9001.GetCustomerFeedbackByEntityId.BusinessObjects.Interfaces;
using ISO9001.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace ISO9001.GetCustomerFeedbackByEntityId.Rest.Mappings
{
    public static class EndpointsMapper
    {
        public static IEndpointRouteBuilder MapGetCustomerFeedbackByEntityIdEndpoint(
            this IEndpointRouteBuilder builder)
        {
            builder.MapGet(("{companyId}/" + GetCustomerFeedbackByEntityIdEndpoint.Entity + "/{entityId}").CreateEndpoint("CustomerFeedbackEndpoints"), async (
                string companyId,
                string entityId,
                IGetCustomerFeedbackByEntityIdInputPort inputPort) =>
            {
                var result = await inputPort.HandleAsync(companyId, entityId);
                return TypedResults.Ok(result);

            });

            return builder;
        }
    }

}
