using ISO9001.Entities.Responses;
using ISO9001.GetNonConformityByAffectedProcess.BusinessObjects;

namespace ISO9001.GetNonConformityByAffectedProcess.Core.Handlers
{
    internal class GetNonConformityByAffectedProcessHandler
        (IGetNonConformityByAffectedProcessRepository repository): IGetNonConformityByAffectedProcessInputPort
    {
        public async Task<IEnumerable<NonConformityMaterResponse>> HandleAsync(string id, string affectedProcess, DateTime? from, DateTime? end)
        {
            DateTime UtcFrom = from != null ? from.Value.Date
                : DateTime.UtcNow.Date.AddDays(-30);

            DateTime UtcEnd = end != null ? end.Value.Date.AddDays(1).AddTicks(-1)
                : DateTime.UtcNow.Date.AddDays(1).AddTicks(-1);

            return await repository.GetNonConformityByAffectedProcesssAsync(id, affectedProcess, UtcFrom, UtcEnd);
        }
    }
}
