using ISO9001.Entities.Dtos;
using ISO9001.Entities.Requests;
using ISO9001.Helpers;
using ISO9001.RegisterNonConformity.BusinessObjects.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace ISO9001.RegisterNonConformity.Rest.Mappings
{
    public static class EndpointsMapper
    {
        public static IEndpointRouteBuilder UseRegisterNonConformityEndpoint(
            this IEndpointRouteBuilder builder)
        {
            builder.MapPost("".CreateEndpoint("NonConformityEndpoints"),
            async (NonConformityRequest nonConformity, IRegisterNonConformityInputPort inputPort) =>
            {

                await inputPort.HandleAsync(new NonConformityDto(
                    nonConformity.EntityId,
                    nonConformity.CompanyId,
                    nonConformity.ReportedAt,
                    nonConformity.ReportedBy,
                    nonConformity.Description,
                    nonConformity.AffectedProcess,
                    nonConformity.Cause,
                    nonConformity.Status
                    ));
                return TypedResults.Created();
            });

            return builder;
        }
    }

}
