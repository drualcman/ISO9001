namespace ISO9001.Core.Features.CustomerFeedback.Controllers;

internal class GenerateCustomerFeedbackReportController(
    IGenerateCustomerFeedbackInputPort inputPort,
    IGenerateCustomerFeedbackOutputPort outputPort)
    : IGenerateCustomerFeedbackReport
{
    public async Task<ReportViewModel> HandleAsync(string companyId, string entityId, DateTime? from, DateTime? end)
    {
        await inputPort.GenerateCustomerFeedbackReportAsync(companyId, entityId, from, end);
        return outputPort.ReportViewModel;
    }
}
