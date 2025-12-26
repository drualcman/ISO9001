namespace ISO9001.WebAPI.Mappers;

public static class CustomerFeedbackMapper
{
    public static IEndpointRouteBuilder MapCustomerFeedbackEndpoints(
        this IEndpointRouteBuilder builder)
    {
        builder.MapPost("".CreateEndpoint("CustomerFeedbackEndpoints"),
            async (CustomerFeedbackRequest customerFeedback, IRegisterCustomerFeedback inputport) =>
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

        builder.MapGet(("{companyId}/" + "Rating" + "/{rating}").CreateEndpoint("CustomerFeedbackEndpoints"), async (
        string companyId,
        int rating,
        [FromQuery] DateTime? from,
        [FromQuery] DateTime? end,
        ICustomerFeedbackByRatingQuery inputPort) =>
        {
            var result = await inputPort.HandleAsync(companyId, rating, from, end);
            return TypedResults.Ok(result);

        });

        builder.MapGet(("{companyId}/" + "Id" + "/{id}").CreateEndpoint("CustomerFeedbackEndpoints"), async (
        string companyId,
        int id,
        ICustomerFeedbackByIdQuery inputport) =>
        {
            var Result = await inputport.HandleAsync(companyId, id);
            return TypedResults.Ok(Result);
        });

        builder.MapGet(("{companyId}/" + "Entity" + "/{entityId}").CreateEndpoint("CustomerFeedbackEndpoints"), async (
        string companyId,
        string entityId,
        [FromQuery] DateTime? from,
        [FromQuery] DateTime? end,
        ICustomerFeedbackByEntityIdQuery inputPort) =>
        {
            var result = await inputPort.HandleAsync(companyId, entityId, from, end);
            return TypedResults.Ok(result);

        });

        builder.MapGet(("{companyId}/" + "Customer" + "/{customerId}").CreateEndpoint("CustomerFeedbackEndpoints"), async (
        string companyId,
        string customerId,
        [FromQuery] DateTime? from,
        [FromQuery] DateTime? end,
        [FromServices] ICustomerFeedbackByCustomerIdQuery inputPort) =>
        {
            var result = await inputPort.HandleAsync(companyId, customerId, from, end);
            return TypedResults.Ok(result);

        });

        builder.MapGet("{companyId}/".CreateEndpoint("CustomerFeedbackEndpoints"), async (
        string companyId,
        [FromQuery] DateTime? from,
        [FromQuery] DateTime? end,
        IAllCustomerFeedbackQuery inputPort) =>
        {
            var result = await inputPort.HandleAsync(companyId, from, end);
            return TypedResults.Ok(result);

        });

        builder.MapGet(("{companyId}/" + "Entity" + "/{entityId}/" + "Report/").CreateEndpoint("CustomerFeedbackEndpoints"), async (
        string companyId,
        string entityId,
        [FromQuery] DateTime? from,
        [FromQuery] DateTime? end,
        IGenerateCustomerFeedbackReport controller) =>
        {
            var result = await controller.HandleAsync(companyId, entityId, from, end);
            return TypedResults.Ok(result);

        });


        return builder;
    }
}