namespace ISO9001.NonConformity.Core.Handlers.GetNonConformityByEntityId
{
    internal class GetNonConformityByEntityIdHandler(
        IQueryableNonConformityRepository repository) : IGetNonConformityByEntityIdInputPort
    {
        public async Task<NonConformityResponse> HandleAsync(string id, string entityId, DateTime? from, DateTime? end)
        {
            DateTime UtcFrom = from != null ? from.Value.Date
                : DateTime.UtcNow.Date.AddDays(-30);

            DateTime UtcEnd = end != null ? end.Value.Date.AddDays(1).AddTicks(-1)
                : DateTime.UtcNow.Date.AddDays(1).AddTicks(-1);

            return await repository.GetNonConformityByEntityIdAsync(id, entityId, UtcFrom, UtcEnd);
        }
    }
}
