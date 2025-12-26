namespace ISO9001.Core.Features.AuditReport.Handlers;

internal class GenerateAuditReportHandler(
    IQueryableAuditReportRepository repository,
    IGenerateAuditReportOutputPort outputPort) : IGenerateAuditReportInputPort
{
    public async ValueTask GenerateAuditReportAsync(string companyId, string entityId, DateTime? from, DateTime? end)
    {
        DateTime UtcFrom = from != null ? from.Value.Date
            : DateTime.UtcNow.Date.AddDays(-30);

        DateTime UtcEnd = end != null ? end.Value.Date.AddDays(1).AddTicks(-1)
            : DateTime.UtcNow.Date.AddDays(1).AddTicks(-1);

        var NonConformities = await repository.GeAllNonConformitiessOrderByReportedAt(companyId, entityId, UtcFrom, UtcEnd);
        var Incidents = await repository.GeAllIncidentReportsOrderByReportedAt(companyId, entityId, UtcFrom, UtcEnd);
        var Feedbacks = await repository.GetAllCustomerFeedbacksOrderByReportedAt(companyId, entityId, UtcFrom, UtcEnd);
        await outputPort.Handle(NonConformities, Incidents, Feedbacks, entityId);

    }
}
