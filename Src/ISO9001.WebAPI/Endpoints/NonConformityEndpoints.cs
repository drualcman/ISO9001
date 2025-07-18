﻿using ISO9001.Entities.Dtos;
using ISO9001.Entities.Requests;
using ISO9001.GetAllNonConformities.BusinessObjects;
using ISO9001.GetNonConformityByAffectedProcess.BusinessObjects;
using ISO9001.GetNonConformityByAffectedProcess.Rest;
using ISO9001.GetNonConformityByEntityId.BusinessObjects;
using ISO9001.GetNonConformityByEntityId.Rest;
using ISO9001.GetNonConformityByStatus.BusinessObjects;
using ISO9001.GetNonConformityByStatus.Rest;
using ISO9001.RegisterNonConformity.BusinessObjects.Interfaces;
using ISO9001.RegisterNonConformityDetail.BusinessObjects.Interfaces;
using ISO9001.RegisterNonConformityDetail.Rest;
using Microsoft.AspNetCore.Mvc;

namespace ISO9001.WebAPI.Endpoints
{
    public static class NonConformityEndpoints
    {
        public static IEndpointRouteBuilder UserNonConformityEndpoints(
            this IEndpointRouteBuilder builder)
        {
            builder.MapPost("".CreateEndpoint(nameof(NonConformityEndpoints)),
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

            builder.MapPost(("{companyId}/" + RegisterNonConformityDetailEndpoint.Detail).CreateEndpoint(nameof(NonConformityEndpoints)),
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

            builder.MapGet("{companyId}/".CreateEndpoint(nameof(NonConformityEndpoints)), async (
                string companyId,
                [FromQuery] DateTime? from,
                [FromQuery] DateTime? end,
                IGetAllNonConformitiesInputPort inputPort) =>
            {
                var result = await inputPort.HandleAsync(companyId, from, end);
                return TypedResults.Ok(result);
            });

            builder.MapGet(("{companyId}/" + GetNonConformityByAffectedProcessEndpoint.AffectedProcess + "/{affectedProcess}").CreateEndpoint(nameof(NonConformityEndpoints)), async (
                string companyId,
                string affectedProcess,
                [FromQuery] DateTime? from,
                [FromQuery] DateTime? end,
                IGetNonConformityByAffectedProcessInputPort inputPort) =>
            {
                var result = await inputPort.HandleAsync(companyId, affectedProcess, from, end);
                return TypedResults.Ok(result);

            });

            builder.MapGet(("{companyId}/" + GetNonConformityByEntityIdEndpoint.Entity + "/{entityId}").CreateEndpoint(nameof(NonConformityEndpoints)), async (
                string companyId,
                string entityId,
                [FromQuery] DateTime? from,
                [FromQuery] DateTime? end,
                IGetNonConformityByEntityIdInputPort inputPort) =>
            {
                var result = await inputPort.HandleAsync(companyId, entityId, from, end);
                return TypedResults.Ok(result);

            });

            builder.MapGet(("{companyId}/" + GetNonConformityByStatusEndpoint.Status + "/{status}").CreateEndpoint(nameof(NonConformityEndpoints)), async (
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
