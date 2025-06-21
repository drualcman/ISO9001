using ISO9001.Entities.Dtos;
using ISO9001.RegisterIncidentReport.BusinessObjects.Interfaces;
using ISO9001.RegisterIncidentReport.Rest;

namespace ISO9001.WebAPI.Endpoints
{
    public static class IncidentReportEndpoints
    {
        const string EntryPoint = "incident/";
        public static IEndpointRouteBuilder UserIncidentReportEndpoints(
            this IEndpointRouteBuilder builder)
        {
            builder.MapPost(RegisterIncidentReportEndpoint.RegisterIncidentReport.CreateEndpoint(EntryPoint),
                async (IncidentReportDto incidentReport, IRegisterIncidentReportInputPort inputport) =>
                {
                    await inputport.HandleAsync(incidentReport);
                    return TypedResults.Created();
                });

            return builder;
        }
    }
}