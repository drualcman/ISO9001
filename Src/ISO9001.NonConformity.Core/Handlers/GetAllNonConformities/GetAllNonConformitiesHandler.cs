namespace ISO9001.NonConformity.Core.Handlers.GetAllNonConformities
{
    internal class GetAllNonConformitiesHandler(
        IQueryableNonConformityRepository repository) : IGetAllNonConformitiesInputPort
    {
        public async Task<IEnumerable<NonConformityMaterResponse>> HandleAsync(string id, DateTime? from, DateTime? end)
        {
            DateTime UtcFrom = from != null ? from.Value.Date
                : DateTime.UtcNow.Date.AddDays(-30);

            DateTime UtcEnd = end != null ? end.Value.Date.AddDays(1).AddTicks(-1)
                : DateTime.UtcNow.Date.AddDays(1).AddTicks(-1);

            return await repository.GetAllNonConformitiesAsync(id, UtcFrom, UtcEnd);
        }
    }
}
