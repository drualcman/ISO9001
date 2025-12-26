namespace ISO9001.Core.Interfaces.NonConformitys;

public interface IAllNonConformitiesQuery
{
    Task<IEnumerable<NonConformityMaterResponse>> HandleAsync(string id, DateTime? from, DateTime? end);
}
