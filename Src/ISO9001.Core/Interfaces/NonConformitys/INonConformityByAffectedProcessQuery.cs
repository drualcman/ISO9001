namespace ISO9001.Core.Interfaces.NonConformitys;

public interface INonConformityByAffectedProcessQuery
{
    Task<IEnumerable<NonConformityMaterResponse>> HandleAsync(string id, string affectedProcess, DateTime? from, DateTime? end);
}
