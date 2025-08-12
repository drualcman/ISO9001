using ISO9001.Entities.Dtos;
using ISO9001.Entities.Requests;
using ISO9001.Helpers;
using ISO9001.RegisterNonConformityDetail.BusinessObjects.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace ISO9001.RegisterNonConformityDetail.Rest.Mappings
{
    public static class EndpointsMapper
    {
        public static IEndpointRouteBuilder MapRegisterNonConformityDetailEndpoint(
            this IEndpointRouteBuilder builder)
        {
            builder.MapPost(("{companyId}/" + RegisterNonConformityDetailEndpoint.Detail).CreateEndpoint("NonConformityEndpoints"),
                async (
                    string companyId,
                    NonConformityCreateDetailRequest nonConformity, IRegisterNonConformityDetailInputPort inputPort) =>
                {
                    NonConformityCreateDetailDto data = new NonConformityCreateDetailDto(
                        Guid.Parse(nonConformity.NonConformityId),
                        companyId,
                        nonConformity.ReportedAt,
                        nonConformity.ReportedBy,
                        nonConformity.Description,
                        nonConformity.Status);
                    await inputPort.HandleAsync(data);
                    return TypedResults.Created();
                });

            return builder;
        }
    }

}
