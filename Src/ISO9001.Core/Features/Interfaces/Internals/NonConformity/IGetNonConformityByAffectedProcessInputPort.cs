using ISO9001.Core.Responses;

namespace ISO9001.Core.Features.Interfaces.Internals.NonConformity;

public interface IGetNonConformityByAffectedProcessInputPort
{
    Task<IEnumerable<NonConformityMaterResponse>> HandleAsync(string id, string affectedProcess, DateTime? from, DateTime? end);
}
