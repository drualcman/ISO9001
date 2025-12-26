using ISO9001.Core.Responses;

namespace ISO9001.Core.Features.Interfaces.Internals.NonConformity;

public interface IGetNonConformityByStatusInputPort
{
    Task<IEnumerable<NonConformityMaterResponse>> HandleAsync(string id, string status, DateTime? from, DateTime? end);
}
