namespace ISO9001.Core.Features.CustomerFeedback.Handlers;

internal class GenerateCustomerFeedbackReportHandler(
    ICustomerFeedbackByEntityIdQuery inputPort,
    IGenerateCustomerFeedbackOutputPort outputPort) : IGenerateCustomerFeedbackInputPort
{
    public async ValueTask GenerateCustomerFeedbackReportAsync(string companyId, string entityId, DateTime? from, DateTime? end)
    {
        DateTime UtcFrom = from != null ? from.Value.Date
            : DateTime.UtcNow.Date.AddDays(-30);

        DateTime UtcEnd = end != null ? end.Value.Date.AddDays(1).AddTicks(-1)
            : DateTime.UtcNow.Date.AddDays(1).AddTicks(-1);

        var CustomerFeedbacks = await inputPort.HandleAsync(companyId, entityId, UtcFrom, UtcEnd);
        await outputPort.Handle(CustomerFeedbacks, entityId);


    }
}
