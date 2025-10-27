namespace ISO9001.NonConformity.Core.Internals.GetNonConformityByEntityId
{
    public interface IGetNonConformityByEntityIdInputPort
    {
        Task<IEnumerable<NonConformityResponse>> HandleAsync(string id, string entityId, DateTime? from, DateTime? end);
    }
}
