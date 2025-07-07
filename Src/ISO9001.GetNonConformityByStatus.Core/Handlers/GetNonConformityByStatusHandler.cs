using ISO9001.Entities.Responses;
using ISO9001.GetNonConformityByStatus.BusinessObjects;

namespace ISO9001.GetNonConformityByStatus.Core.Handlers
{
    internal class GetNonConformityByStatusHandler(
        IGetNonConformityByStatusRepository repository) : IGetNonConformityByStatusInputPort
    {
        public async Task<IEnumerable<NonConformityMaterResponse>> HandleAsync(string id, string status, DateTime? from, DateTime? end)
        {
            DateTime UtcFrom = from != null ? from.Value.Date
                : DateTime.UtcNow.Date.AddDays(-30);

            DateTime UtcEnd = end != null ? end.Value.Date.AddDays(1).AddTicks(-1)
                : DateTime.UtcNow.Date.AddDays(1).AddTicks(-1);

            return await repository.GetNonConformityByStatusAsync(id, status, UtcFrom, UtcEnd);
        }
    }
}
