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

            builder.MapGet("{companyId}/".CreateEndpoint(nameof(CustomerFeedbackEndpoints)), async (
                string companyId,
                [FromQuery] DateTime? from,
                [FromQuery] DateTime? end,
                IGetAllCustomerFeedbackInputPort inputPort) =>
            {
                var result = await inputPort.HandleAsync(companyId, from, end);
                return TypedResults.Ok(result);

            });

            builder.MapGet(("{companyId}/" + GetCustomerFeedbackByEntityIdEndpoint.Entity + "/{entityId}").CreateEndpoint(nameof(CustomerFeedbackEndpoints)), async (
                string companyId,
                string entityId,
                IGetCustomerFeedbackByEntityIdInputPort inputPort) =>
            {
                var result = await inputPort.HandleAsync(companyId, entityId);
                return TypedResults.Ok(result);

            });

            builder.MapGet(("{companyId}/" + GetCustomerFeedbackByCustomerIdEndpoint.Customer + "/{customerId}").CreateEndpoint(nameof(CustomerFeedbackEndpoints)), async (
                string companyId,
                string customerId,
                [FromQuery] DateTime? from,
                [FromQuery] DateTime? end,
                IGetCustomerFeedbackByCustomerIdInputPort inputPort) =>
            {
                var result = await inputPort.HandleAsync(companyId, customerId, from, end);
                return TypedResults.Ok(result);

            });

            builder.MapGet(("{companyId}/" + GetCustomerFeedbackByRatingEndpoint.Rating + "/{rating}").CreateEndpoint(nameof(CustomerFeedbackEndpoints)), async (
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
