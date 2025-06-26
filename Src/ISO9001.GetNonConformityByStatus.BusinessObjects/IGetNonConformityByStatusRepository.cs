using ISO9001.Entities.Responses;

namespace ISO9001.GetNonConformityByStatus.BusinessObjects
{
    public interface IGetNonConformityByStatusRepository
    {
        Task<IEnumerable<NonConformityResponse>> GetNonConformityByStatusAsync(string id, string status, DateTime? from, DateTime? end);

    }
}
