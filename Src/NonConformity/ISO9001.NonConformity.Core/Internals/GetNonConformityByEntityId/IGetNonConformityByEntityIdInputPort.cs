namespace ISO9001.NonConformity.Core.Internals.GetNonConformityByEntityId
{
    public interface IGetNonConformityByEntityIdInputPort
    {
        Task<NonConformityResponse> HandleAsync(string id, string entityId, DateTime? from, DateTime? end);
    }
}
