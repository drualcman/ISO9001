namespace ISO9001.Core.Interfaces.NonConformitys;

public interface INonConformityByEntityIdQuery
{
    Task<NonConformityResponse> HandleAsync(string id, string entityId, DateTime? from, DateTime? end);
}
