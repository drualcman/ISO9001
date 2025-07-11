using ISO9001.Entities.Dtos;
using ISO9001.Entities.Requests;
using ISO9001.GetAllIncidentReports.BusinessObjects.Interfaces;
using ISO9001.GetAllIncidentReports.Rest;
using ISO9001.RegisterIncidentReport.BusinessObjects.Interfaces;
using ISO9001.RegisterIncidentReport.Rest;
using Microsoft.AspNetCore.Mvc;

namespace ISO9001.WebAPI.Endpoints
{
    public static class IncidentReportEndpoints
    {
        const string EntryPoint = "incident/";
        public static IEndpointRouteBuilder UserIncidentReportEndpoints(
            this IEndpointRouteBuilder builder)
        {
            builder.MapPost(RegisterIncidentReportEndpoint.RegisterIncidentReport.CreateEndpoint(EntryPoint),
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

            builder.MapGet(("{id}/" + GetAllIncidentReportsEndpoint.GetAllIncidentReports).CreateEndpoint(EntryPoint), async (
                string id,
                [FromQuery] DateTime? from,
                [FromQuery] DateTime? end,
                IGetAllIncidentReportsInputPort inputPort) =>
            {
                var result = await inputPort.HandleAsync(id, from, end);
                return TypedResults.Ok(result);

            });

            return builder;
        }
    }
}