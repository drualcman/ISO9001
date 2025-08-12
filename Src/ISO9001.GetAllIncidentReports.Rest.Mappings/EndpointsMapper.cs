using ISO9001.GetAllIncidentReports.BusinessObjects.Interfaces;
using ISO9001.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace ISO9001.GetAllIncidentReports.Rest.Mappings
{
    public static class EndpointsMapper
    {
        public static IEndpointRouteBuilder MapGetAllIncidentReportsEndpoint(
            this IEndpointRouteBuilder builder)
        {
            builder.MapGet("{companyId}/".CreateEndpoint("IncidentReportEndpoints"), async (
                string companyId,
                [FromQuery] DateTime? from,
                [FromQuery] DateTime? end,
                IGetAllIncidentReportsInputPort inputPort) =>
            {
                var result = await inputPort.HandleAsync(companyId, from, end);
                return TypedResults.Ok(result);

            });

            return builder;
        }
    }

}
