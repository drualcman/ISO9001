using ISO9001.GetIncidentReportById.BusinessObjects.Interfaces;
using ISO9001.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace ISO9001.GetIncidentReportById.Mappings
{
    public static class EndpointsMapper
    {
        public static IEndpointRouteBuilder UseGetIncidentReportByIdEndpoint(
            this IEndpointRouteBuilder builder)
        {
            builder.MapGet(("{companyId}/" + GetIncidentReportByIdEndpoint.Id + "/{id}").CreateEndpoint("IncidentReportEndpoints"), async (
                string companyId,
                int id,
                IGetIncidentReportByIdInputPort inputPort) =>
            {
                var Result = await inputPort.HandleAsync(companyId, id);
                return TypedResults.Ok(Result);
            }
            );

            return builder;
        }
    }

}
