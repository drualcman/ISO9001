using ISO9001.Entities.Responses;

namespace ISO9001.GetNonConformityByAffectedProcess.BusinessObjects
{
    public interface IGetNonConformityByAffectedProcessRepository
    {
        Task<IEnumerable<NonConformityResponse>> GetNonConformityByAffectedProcesssAsync(string id, string affectedProcess, DateTime? from, DateTime? end);
    }
}
