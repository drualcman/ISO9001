using ISO9001.Core.Responses;

namespace ISO9001.Core.Features.Interfaces.Internals.NonConformity;

public interface IGetAllNonConformitiesInputPort
{
    Task<IEnumerable<NonConformityMaterResponse>> HandleAsync(string id, DateTime? from, DateTime? end);
}
