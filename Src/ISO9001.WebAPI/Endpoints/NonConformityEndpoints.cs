using ISO9001.Entities.Dtos;
using ISO9001.RegisterNonConformity.BusinessObjects.Interfaces;
using ISO9001.RegisterNonConformity.Rest;

namespace ISO9001.WebAPI.Endpoints
{
    public static class RegisterNonConformityEndpoints
    {
        const string EntryPoint = "non-conformity/";

        public static IEndpointRouteBuilder UserNonConformityEndpoints(
            this IEndpointRouteBuilder builder)
        {
            builder.MapPost(RegisterNonConformityEndpoint.RegisterNonConformity.CreateEndpoint(EntryPoint),
                async (NonConformityDto nonConformity, IRegisterNonConformityInputPort inputPort) =>
                {
                    await inputPort.HandleAsync(nonConformity);
                    return TypedResults.Created();
                });

            return builder;
        }
    }
}
