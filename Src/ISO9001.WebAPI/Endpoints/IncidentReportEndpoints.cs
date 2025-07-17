using ISO9001.Entities.Dtos;
using ISO9001.Entities.Requests;
using ISO9001.GetAllIncidentReports.BusinessObjects.Interfaces;
using ISO9001.RegisterIncidentReport.BusinessObjects.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ISO9001.WebAPI.Endpoints
{
    public static class IncidentReportEndpoints
    {
        public static IEndpointRouteBuilder UserIncidentReportEndpoints(
            this IEndpointRouteBuilder builder)
        {
            builder.MapPost("".CreateEndpoint(nameof(IncidentReportEndpoints)),
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

            builder.MapGet("{companyId}/".CreateEndpoint(nameof(IncidentReportEndpoints)), async (
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