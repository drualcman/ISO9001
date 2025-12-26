namespace ISO9001.Core.Features.NonConformity.Handlers;

internal class GenerateNonConformityMasterReportHandler(
    IQueryableNonConformityRepository repository,
    IGenerateNonConformityMasterReportOutputPort outputPort) : IGenerateNonConformityMasterReportInputPort
{
    public async ValueTask GenerateNonConformityMasterReportAsync(string companyId, string entityId, DateTime? from, DateTime? end)
    {
        DateTime UtcFrom = from != null ? from.Value.Date
            : DateTime.UtcNow.Date.AddDays(-30);

        DateTime UtcEnd = end != null ? end.Value.Date.AddDays(1).AddTicks(-1)
            : DateTime.UtcNow.Date.AddDays(1).AddTicks(-1);


        var NonConformities = await repository.GetNonCormityMasterByEntityIdAsync(companyId, entityId, UtcFrom, UtcEnd);
        await outputPort.Handle(NonConformities, companyId);
    }
}
