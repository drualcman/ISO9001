using ISO9001.Entities.Dtos;
using ISO9001.Entities.Requests;
using ISO9001.Helpers;
using ISO9001.RegisterIncidentReport.BusinessObjects.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace ISO9001.RegisterIncidentReport.Rest.Mappings
{
    public static class EndpointsMapper
    {
        public static IEndpointRouteBuilder UseRegisterIncidentReportEndpoint(
            this IEndpointRouteBuilder builder)
        {
            builder.MapPost("".CreateEndpoint("IncidentReportEndpoints"),
                async (IncidentReportRequest incidentReport, IRegisterIncidentReportInputPort inputport) =>
                {
                    await inputport.HandleAsync(new IncidentReportDto(
                        incidentReport.CompanyId,
                        incidentReport.EntityId,
                        incidentReport.ReportedAt,
                        incidentReport.UserId,
                        incidentReport.Description,
                        incidentReport.AffectedProcess,
                        incidentReport.Severity,
                        incidentReport.Data)
                        );
                    return TypedResults.Created();
                });

            return builder;
        }
    }

}
