﻿namespace ISO9001.NonConformity.Rest.Mappings
{
    public static class EndpointsMapper
    {
        public static IEndpointRouteBuilder MapNonConformityEndpoints(
            this IEndpointRouteBuilder builder)
        {
            builder.MapGet("{companyId}/".CreateEndpoint("NonConformityEndpoints"), async (
                string companyId,
                [FromQuery] DateTime? from,
                [FromQuery] DateTime? end,
                IGetAllNonConformitiesInputPort inputPort) =>
            {
                var result = await inputPort.HandleAsync(companyId, from, end);
                return TypedResults.Ok(result);
            });

            builder.MapGet(("{companyId}/" + "AffectedProcess"+ "/{affectedProcess}").CreateEndpoint("NonConformityEndpoints"), async (
                string companyId,
                string affectedProcess,
                [FromQuery] DateTime? from,
                [FromQuery] DateTime? end,
                IGetNonConformityByAffectedProcessInputPort inputPort) =>
            {
                var result = await inputPort.HandleAsync(companyId, affectedProcess, from, end);
                return TypedResults.Ok(result);
            });

            builder.MapGet(("{companyId}/" + "Entity" + "/{entityId}").CreateEndpoint("NonConformityEndpoints"), async (
                string companyId,
                string entityId,
                [FromQuery] DateTime? from,
                [FromQuery] DateTime? end,
                IGetNonConformityByEntityIdInputPort inputPort) =>
            {
                var result = await inputPort.HandleAsync(companyId, entityId, from, end);
                return TypedResults.Ok(result);

            });

            builder.MapGet(("{companyId}/" + "Status" + "/{status}").CreateEndpoint("NonConformityEndpoints"), async (
                string companyId,
                string status,
                [FromQuery] DateTime? from,
                [FromQuery] DateTime? end,
                IGetNonConformityByStatusInputPort inputPort) =>
            {
                var result = await inputPort.HandleAsync(companyId, status, from, end);
                return TypedResults.Ok(result);

            });

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

            builder.MapPost(("{companyId}/" + "Detail").CreateEndpoint("NonConformityEndpoints"),
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
