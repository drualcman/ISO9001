using ISO9001.Entities.Dtos;
using ISO9001.Entities.Requests;
using ISO9001.GetAllCustomerFeedback.BusinessObjects.Interfaces;
using ISO9001.GetCustomerFeedbackByCustomerId.BusinessObjects.Interfaces;
using ISO9001.GetCustomerFeedbackByCustomerId.Rest;
using ISO9001.GetCustomerFeedbackByEntityId.BusinessObjects.Interfaces;
using ISO9001.GetCustomerFeedbackByEntityId.Rest;
using ISO9001.GetCustomerFeedbackByRating.BusinessObjects.Interfaces;
using ISO9001.GetCustomerFeedbackByRating.Rest;
using ISO9001.RegisterCustomerFeedback.BusinessObjects.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ISO9001.WebAPI.Endpoints
{
    public static class CustomerFeedbackEndpoints
    {
        public static IEndpointRouteBuilder UserCustomerFeedbackEndpoints(
            this IEndpointRouteBuilder builder)
        {
            builder.MapPost("".CreateEndpoint(nameof(CustomerFeedbackEndpoints)),
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

            builder.MapGet("{id}/".CreateEndpoint(nameof(CustomerFeedbackEndpoints)), async (
                string id,
                [FromQuery] DateTime? from,
                [FromQuery] DateTime? end,
                IGetAllCustomerFeedbackInputPort inputPort) =>
            {
                var result = await inputPort.HandleAsync(id, from, end);
                return TypedResults.Ok(result);

            });

            builder.MapGet(("{id}/" + GetCustomerFeedbackByEntityIdEndpoint.ByEntity + "/{entityId}").CreateEndpoint(nameof(CustomerFeedbackEndpoints)), async (
                string id,
                string entityId,
                IGetCustomerFeedbackByEntityIdInputPort inputPort) =>
            {
                var result = await inputPort.HandleAsync(id, entityId);
                return TypedResults.Ok(result);

            });

            builder.MapGet(("{id}/" + GetCustomerFeedbackByCustomerIdEndpoint.ByCustomer + "/{customerId}").CreateEndpoint(nameof(CustomerFeedbackEndpoints)), async (
                string id,
                string customerId,
                [FromQuery] DateTime? from,
                [FromQuery] DateTime? end,
                IGetCustomerFeedbackByCustomerIdInputPort inputPort) =>
            {
                var result = await inputPort.HandleAsync(id, customerId, from, end);
                return TypedResults.Ok(result);

            });

            builder.MapGet(("{id}/" + GetCustomerFeedbackByRatingEndpoint.ByRating + "/{rating}").CreateEndpoint(nameof(CustomerFeedbackEndpoints)), async (
                string id,
                int rating,
                [FromQuery] DateTime? from,
                [FromQuery] DateTime? end,
                IGetCustomerFeedbackByRatingInputPort inputPort) =>
            {
                var result = await inputPort.HandleAsync(id, rating, from, end);
                return TypedResults.Ok(result);

            });

            return builder;
        }
    }
}
