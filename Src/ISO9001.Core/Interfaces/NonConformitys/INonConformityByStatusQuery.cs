namespace ISO9001.Core.Interfaces.NonConformitys;

public interface INonConformityByStatusQuery
{
    Task<IEnumerable<NonConformityMaterResponse>> HandleAsync(string id, string status, DateTime? from, DateTime? end);
}
