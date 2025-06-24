using ISO9001.Entities.Dtos;
using ISO9001.GetAllCustomerFeedback.BusinessObjects.Interfaces;
using ISO9001.GetAllCustomerFeedback.Rest;
using ISO9001.GetCustomerFeedbackByCustomerId.BusinessObjects.Interfaces;
using ISO9001.GetCustomerFeedbackByCustomerId.Rest;
using ISO9001.GetCustomerFeedbackByEntityId.BusinessObjects.Interfaces;
using ISO9001.GetCustomerFeedbackByEntityId.Rest;
using ISO9001.GetCustomerFeedbackByRating.BusinessObjects.Interfaces;
using ISO9001.GetCustomerFeedbackByRating.Rest;
using ISO9001.RegisterCustomerFeedback.BusinessObjects.Interfaces;
using ISO9001.RegisterCustomerFeedback.Rest;
using Microsoft.AspNetCore.Mvc;

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

            builder.MapGet(("{id}/" + GetAllCustomerFeedbackEndpoint.GetAllCustomerFeedback).CreateEndpoint(EntryPoint), async (
                string id,
                [FromQuery] DateTime? from,
                [FromQuery] DateTime? end,
                IGetAllCustomerFeedbackInputPort inputPort) =>
            {
                var result = await inputPort.HandleAsync(id, from, end);
                return TypedResults.Ok(result);

            });

            builder.MapGet(("{id}/" + GetCustomerFeedbackByEntityIdEndpoint.GetCustomerFeedbackByEntityId + "/{entityId}").CreateEndpoint(EntryPoint), async (
                string id,
                string entityId,
                IGetCustomerFeedbackByEntityIdInputPort inputPort) =>
            {
                var result = await inputPort.HandleAsync(id, entityId);
                return TypedResults.Ok(result);

            });

            builder.MapGet(("{id}/" + GetCustomerFeedbackByCustomerIdEndpoint.GetCustomerFeedbackByCustomerId + "/{customerId}").CreateEndpoint(EntryPoint), async (
                string id,
                string customerId,
                [FromQuery] DateTime? from,
                [FromQuery] DateTime? end,
                IGetCustomerFeedbackByCustomerIdInputPort inputPort) =>
            {
                var result = await inputPort.HandleAsync(id, customerId, from, end);
                return TypedResults.Ok(result);

            });

            builder.MapGet(("{id}/" + GetCustomerFeedbackByRatingEndpoint.GetCustomerFeedbackByRating + "/{rating}").CreateEndpoint(EntryPoint), async (
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
