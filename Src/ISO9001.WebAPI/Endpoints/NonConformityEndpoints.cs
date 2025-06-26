using ISO9001.Entities.Dtos;
using ISO9001.GetAllNonConformities.BusinessObjects;
using ISO9001.GetAllNonConformities.Rest;
using ISO9001.GetNonConformityByAffectedProcess.BusinessObjects;
using ISO9001.GetNonConformityByAffectedProcess.Rest;
using ISO9001.GetNonConformityByEntityId.BusinessObjects;
using ISO9001.GetNonConformityByEntityId.Rest;
using ISO9001.GetNonConformityByStatus.BusinessObjects;
using ISO9001.GetNonConformityByStatus.Rest;
using ISO9001.RegisterNonConformity.BusinessObjects.Interfaces;
using ISO9001.RegisterNonConformity.Rest;
using Microsoft.AspNetCore.Mvc;

namespace ISO9001.WebAPI.Endpoints
{
    public static class RegisterNonConformityEndpoints
    {
        const string EntryPoint = "non-conformity/";

        public static IEndpointRouteBuilder UserNonConformityEndpoints(
            this IEndpointRouteBuilder builder)
        {
            builder.MapPost(RegisterNonConformityEndpoint.RegisterNonConformity.CreateEndpoint(EntryPoint),
                async (NonConformityDto nonConformity, IRegisterNonConformityInputPort inputPort) =>
                {
                    await inputPort.HandleAsync(nonConformity);
                    return TypedResults.Created();
                });

            builder.MapGet(("{id}/" + GetAllNonConformitiesEndpoint.GetAllNonConformities).CreateEndpoint(EntryPoint), async (
                string id,
                [FromQuery] DateTime? from,
                [FromQuery] DateTime? end,
                IGetAllNonConformitiesInputPort inputPort) =>
            {
                var result = await inputPort.HandleAsync(id, from, end);
                return TypedResults.Ok(result);

            });

            builder.MapGet(("{id}/" + GetNonConformityByAffectedProcessEndpoint.GetNonConformityByAffectedProcess + "/{affectedProcess}").CreateEndpoint(EntryPoint), async (
                string id,
                string affectedProcess,
                [FromQuery] DateTime? from,
                [FromQuery] DateTime? end,
                IGetNonConformityByAffectedProcessInputPort inputPort) =>
            {
                var result = await inputPort.HandleAsync(id, affectedProcess, from, end);
                return TypedResults.Ok(result);

            });

            builder.MapGet(("{id}/" + GetNonConformityByEntityIdEndpoint.GetNonConformityById + "/{entityId}").CreateEndpoint(EntryPoint), async (
                string id,
                string entityId,
                [FromQuery] DateTime? from,
                [FromQuery] DateTime? end,
                IGetNonConformityByEntityIdInputPort inputPort) =>
            {
                var result = await inputPort.HandleAsync(id, entityId, from, end);
                return TypedResults.Ok(result);

            });

            builder.MapGet(("{id}/" + GetNonConformityByStatusEndpoint.GetNonConformityByStatus+ "/{status}").CreateEndpoint(EntryPoint), async (
                string id,
                string status,
                [FromQuery] DateTime? from,
                [FromQuery] DateTime? end,
                IGetNonConformityByStatusInputPort inputPort) =>
            {
                var result = await inputPort.HandleAsync(id, status, from, end);
                return TypedResults.Ok(result);

            });

            return builder;
        }
    }
}
