using ISO9001.Entities.Dtos;
using ISO9001.Entities.Requests;
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
using ISO9001.RegisterNonConformityDetail.BusinessObjects.Interfaces;
using ISO9001.RegisterNonConformityDetail.Rest;
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

            builder.MapPost("{companyId}/" + RegisterNonConformityDetailEndpoint.RegisterNonConformityDetail.CreateEndpoint(EntryPoint) + "{id}/detail",
                async (
                    string companyId,
                    string id,
                    NonConformityCreateDetailRequest nonConformity, IRegisterNonConformityDetailInputPort inputPort) =>
                {
                    NonConformityDto data = new NonConformityDto
                    {
                        CompanyId = companyId,
                        EntityId = id,
                        Description = nonConformity.Description,
                        ReportedAt = nonConformity.ReportedAt,
                        ReportedBy = nonConformity.ReportedBy,
                        Status = nonConformity.Status
                    };
                    await inputPort.HandleAsync(data);
                    return TypedResults.Created();
                });

            builder.MapGet(("{companyId}/" + GetAllNonConformitiesEndpoint.GetAllNonConformities).CreateEndpoint(EntryPoint), async (
                string companyId,
                [FromQuery] DateTime? from,
                [FromQuery] DateTime? end,
                IGetAllNonConformitiesInputPort inputPort) =>
            {
                var result = await inputPort.HandleAsync(companyId, from, end);
                return TypedResults.Ok(result);

            });

            builder.MapGet(("{companyId}/" + GetNonConformityByAffectedProcessEndpoint.GetNonConformityByAffectedProcess + "/{affectedProcess}").CreateEndpoint(EntryPoint), async (
                string companyId,
                string affectedProcess,
                [FromQuery] DateTime? from,
                [FromQuery] DateTime? end,
                IGetNonConformityByAffectedProcessInputPort inputPort) =>
            {
                var result = await inputPort.HandleAsync(companyId, affectedProcess, from, end);
                return TypedResults.Ok(result);

            });

            builder.MapGet(("{companyId}/" + GetNonConformityByEntityIdEndpoint.GetNonConformityByEntityId + "/{entityId}").CreateEndpoint(EntryPoint), async (
                string companyId,
                string entityId,
                [FromQuery] DateTime? from,
                [FromQuery] DateTime? end,
                IGetNonConformityByEntityIdInputPort inputPort) =>
            {
                var result = await inputPort.HandleAsync(companyId, entityId);
                return TypedResults.Ok(result);

            });

            builder.MapGet(("{companyId}/" + GetNonConformityByStatusEndpoint.GetNonConformityByStatus + "/{status}").CreateEndpoint(EntryPoint), async (
                string companyId,
                string status,
                [FromQuery] DateTime? from,
                [FromQuery] DateTime? end,
                IGetNonConformityByStatusInputPort inputPort) =>
            {
                var result = await inputPort.HandleAsync(companyId, status, from, end);
                return TypedResults.Ok(result);

            });

            return builder;
        }
    }
}
