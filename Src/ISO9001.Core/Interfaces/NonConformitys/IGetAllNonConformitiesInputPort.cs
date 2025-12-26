namespace ISO9001.Core.Interfaces.NonConformitys;

public interface IGetAllNonConformitiesInputPort
{
    Task<IEnumerable<NonConformityMaterResponse>> HandleAsync(string id, DateTime? from, DateTime? end);
}
