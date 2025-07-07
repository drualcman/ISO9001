using ISO9001.Entities.Responses;

namespace ISO9001.GetNonConformityByAffectedProcess.BusinessObjects
{
    public interface IGetNonConformityByAffectedProcessInputPort
    {
        Task<IEnumerable<NonConformityMaterResponse>> HandleAsync(string id, string affectedProcess, DateTime? from,  DateTime? end);
    }
}
