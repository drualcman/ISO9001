using ISO9001.Entities.Responses;

namespace ISO9001.GetAllNonConformities.BusinessObjects
{
    public interface IGetAllNonConformitiesInputPort
    {
        Task<IEnumerable<NonConformityResponse>> HandleAsync(string id, DateTime? from, DateTime? end);
    }
}
