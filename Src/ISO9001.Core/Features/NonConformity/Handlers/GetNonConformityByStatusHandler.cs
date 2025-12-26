namespace ISO9001.Core.Features.NonConformity.Handlers;

internal class GetNonConformityByStatusHandler(
    IQueryableNonConformityRepository repository) : INonConformityByStatusQuery
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
