using ISO9001.Entities.Responses;

namespace ISO9001.GetNonConformityByStatus.BusinessObjects
{
    public interface IGetNonConformityByStatusInputPort
    {
        Task<IEnumerable<NonConformityResponse>> HandleAsync(string id, string status, DateTime? from, DateTime? end);

    }
}
