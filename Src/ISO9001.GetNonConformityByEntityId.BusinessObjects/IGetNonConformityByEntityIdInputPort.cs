using ISO9001.Entities.Responses;

namespace ISO9001.GetNonConformityByEntityId.BusinessObjects
{
    public interface IGetNonConformityByEntityIdInputPort
    {
        Task<IEnumerable<NonConformityResponse>> HandleAsync(string id, string entityId, DateTime? from, DateTime? end);

    }
}
