using ISO9001.Entities.Responses;

namespace ISO9001.GetAllNonConformities.BusinessObjects
{
    public interface IGetAllNonConformitiesRepository
    {
        Task<IEnumerable<NonConformityResponse>> GetAllNonConformitiesAsync(string id, DateTime? from, DateTime? end);
    }
}
