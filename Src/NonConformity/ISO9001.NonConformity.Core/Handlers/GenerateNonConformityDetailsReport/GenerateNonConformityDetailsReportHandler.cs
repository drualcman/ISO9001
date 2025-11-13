
namespace ISO9001.NonConformity.Core.Handlers.GenerateNonConformityDetailsReport;
internal class GenerateNonConformityDetailsReportHandler(
    IGetNonConformityByEntityIdInputPort inputPort,
    IQueryableNonConformityRepository queryRepository,
    IGenerateNonConformityDetailsReportOutputPort outputPort): IGenerateNonConformityDetailsReportInputPort
{
    public async ValueTask GenerateNonConformityDetailsReportAsync(string companyId, 
        string nonConformityId, DateTime? from, DateTime? end)
    {


        if (Guid.TryParse(nonConformityId, out Guid id))
        {
            bool NonConformityExists = await queryRepository.NonConformityExistsByGuidAsync(id);
            if (!NonConformityExists)
            {
                throw new InvalidOperationException("NonConformity doesn't exist");
            }
            else
            {
                DateTime UtcFrom = from != null ? from.Value.Date
                    : DateTime.UtcNow.Date.AddDays(-30);

                DateTime UtcEnd = end != null ? end.Value.Date.AddDays(1).AddTicks(-1)
                    : DateTime.UtcNow.Date.AddDays(1).AddTicks(-1);

                NonConformityResponse NonConformity = await inputPort.HandleAsync(companyId,
                    nonConformityId, UtcFrom, UtcEnd);

                await outputPort.Handle(NonConformity.Details, companyId);
            }
        }
        else
        {
            throw new FormatException($"El valor '{nonConformityId}' no es un GUID válido.");
        }

    }
}
