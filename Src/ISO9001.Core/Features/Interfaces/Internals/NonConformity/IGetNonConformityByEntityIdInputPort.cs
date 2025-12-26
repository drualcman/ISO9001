using ISO9001.Core.Responses;

namespace ISO9001.Core.Features.Interfaces.Internals.NonConformity;

public interface IGetNonConformityByEntityIdInputPort
{
    Task<NonConformityResponse> HandleAsync(string id, string entityId, DateTime? from, DateTime? end);
}
