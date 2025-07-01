using ISO9001.Entities.Responses;

namespace ISO9001.GetNonConformityByEntityId.BusinessObjects
{
    public interface IGetNonConformityByEntityIdRepository
    {
        Task<IEnumerable<NonConformityResponse>> GetNonConformityByEntityIdAsync(string id, string entityId);
    }
}
