namespace ISO9001.WebAPI.Mappers;

public static class IncidentReportMapper
{
    public static IEndpointRouteBuilder MapIncidentReportEndpoints(
        this IEndpointRouteBuilder builder)
    {

        builder.MapGet("{companyId}/".CreateEndpoint("IncidentReportEndpoints"), async (
            string companyId,
            [FromQuery] DateTime? from,
            [FromQuery] DateTime? end,
            IAllIncidentReportsQuery inputPort) =>
        {
            var result = await inputPort.HandleAsync(companyId, from, end);
            return TypedResults.Ok(result);

        });

        builder.MapGet("{companyId}/Entity/{entityId}".CreateEndpoint("IncidentReportEndpoints"), async (
            string companyId,
            string entityId,
            [FromQuery] DateTime? from,
            [FromQuery] DateTime? end,
            IIncidentReportByEntityIdQuery inputPort) =>
        {
            var Result = await inputPort.HandleAsync(companyId, entityId, from, end);
            return TypedResults.Ok(Result);
        }
        );



        builder.MapGet("{companyId}/Id/{id}".CreateEndpoint("IncidentReportEndpoints"), async (
            string companyId,
            string id,
            IGetIncidentReportByIdInputPort inputPort) =>
        {
            var Result = await inputPort.HandleAsync(companyId, id);
            return TypedResults.Ok(Result);
        }
        );

        builder.MapPost("".CreateEndpoint("IncidentReportEndpoints"),
            async (IncidentReportRequest incidentReport, IRegisterIncidentReport inputport) =>
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

        builder.MapGet("{companyId}/Entity/{entityId}/Report/".CreateEndpoint("IncidentReportEndpoints"), async (
        string companyId,
        string entityId,
        [FromQuery] DateTime? from,
        [FromQuery] DateTime? end,
        IGenerateIncidentReportReport controller) =>
        {
            var result = await controller.HandleAsync(companyId, entityId, from, end);
            return TypedResults.Ok(result);

        });

        return builder;
    }
}