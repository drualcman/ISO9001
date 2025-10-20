namespace ISO9001.NonConformity.Core.Internals.GetNonConformityByAffectedProcess
{
    public interface IGetNonConformityByAffectedProcessInputPort
    {
        Task<IEnumerable<NonConformityMaterResponse>> HandleAsync(string id, string affectedProcess, DateTime? from, DateTime? end);
    }
}
