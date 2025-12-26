namespace ISO9001.Core.Interfaces.NonConformitys;

public interface IGetNonConformityByStatusInputPort
{
    Task<IEnumerable<NonConformityMaterResponse>> HandleAsync(string id, string status, DateTime? from, DateTime? end);
}
