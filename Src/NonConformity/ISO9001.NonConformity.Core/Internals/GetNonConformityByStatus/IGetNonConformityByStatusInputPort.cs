namespace ISO9001.NonConformity.Core.Internals.GetNonConformityByStatus
{
    public interface IGetNonConformityByStatusInputPort
    {
        Task<IEnumerable<NonConformityMaterResponse>> HandleAsync(string id, string status, DateTime? from, DateTime? end);
    }
}
