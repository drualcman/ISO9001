namespace ISO9001.WebAPI.Mappers;

public static class NonConformityMapper
{
    public static IEndpointRouteBuilder MapNonConformityEndpoints(
        this IEndpointRouteBuilder builder)
    {
        builder.MapGet("{companyId}/".CreateEndpoint("NonConformityEndpoints"), async (
            string companyId,
            [FromQuery] DateTime? from,
            [FromQuery] DateTime? end,
            IAllNonConformitiesQuery inputPort) =>
        {
            var result = await inputPort.HandleAsync(companyId, from, end);
            return TypedResults.Ok(result);
        });

        builder.MapGet("{companyId}/AffectedProcess/{affectedProcess}".CreateEndpoint("NonConformityEndpoints"), async (
            string companyId,
            string affectedProcess,
            [FromQuery] DateTime? from,
            [FromQuery] DateTime? end,
            INonConformityByAffectedProcessQuery inputPort) =>
        {
            var result = await inputPort.HandleAsync(companyId, affectedProcess, from, end);
            return TypedResults.Ok(result);
        });

        builder.MapGet("{companyId}/Entity/{entityId}".CreateEndpoint("NonConformityEndpoints"), async (
            string companyId,
            string entityId,
            [FromQuery] DateTime? from,
            [FromQuery] DateTime? end,
            INonConformityByEntityIdQuery inputPort) =>
        {
            var result = await inputPort.HandleAsync(companyId, entityId, from, end);
            return TypedResults.Ok(result);

        });

        builder.MapGet("{companyId}/Status/{status}".CreateEndpoint("NonConformityEndpoints"), async (
            string companyId,
            string status,
            [FromQuery] DateTime? from,
            [FromQuery] DateTime? end,
            INonConformityByStatusQuery inputPort) =>
        {
            var result = await inputPort.HandleAsync(companyId, status, from, end);
            return TypedResults.Ok(result);

        });

        builder.MapPost("".CreateEndpoint("NonConformityEndpoints"),
        async (NonConformityRequest nonConformity, IRegisterNonConformity inputPort) =>
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

        builder.MapPost("{companyId}/Detail".CreateEndpoint("NonConformityEndpoints"),
            async (
                string companyId,
                NonConformityCreateDetailRequest nonConformity, IRegisterNonConformityDetail inputPort) =>
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

        builder.MapGet("{companyId}/Entity/{entityId}/Report/".CreateEndpoint("NonConformityEndpoints"), async (
        string companyId,
        string entityId,
        [FromQuery] DateTime? from,
        [FromQuery] DateTime? end,
        IGenerateNonConformityMasterReport controller) =>
        {
            var result = await controller.HandleAsync(companyId, entityId, from, end);
            return TypedResults.Ok(result);

        });

        builder.MapGet("{companyId}/MasterId/{masterId}/Report/".CreateEndpoint("NonConformityEndpoints"), async (
        string companyId,
        string masterId,
        [FromQuery] DateTime? from,
        [FromQuery] DateTime? end,
        IGenerateNonConformityDetailsReport controller) =>
        {
            var result = await controller.HandleAsync(companyId, masterId, from, end);
            return TypedResults.Ok(result);

        });
        return builder;
    }


}