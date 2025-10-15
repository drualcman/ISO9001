namespace ISO9001.NonConformity.Core.Internals.GetAllNonConformities
{
    public interface IGetAllNonConformitiesInputPort
    {
        Task<IEnumerable<NonConformityMaterResponse>> HandleAsync(string id, DateTime? from, DateTime? end);
    }
}
