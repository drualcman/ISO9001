using DigitalDoor.Reporting.Entities.ViewModels;
using ISO9001.CustomerFeedback.Core.Internals.GenerateCustomerFeedbackReport;

namespace ISO9001.CustomerFeedback.Core.Controllers.GenerateCustomerFeedbackReport
{
    internal class GenerateCustomerFeedbackReportController(
        IGenerateCustomerFeedbackInputPort inputPort,
        IGenerateCustomerFeedbackOutputPort outputPort)
        : IGenerateCustomerFeedbackController
    {
        public async Task<ReportViewModel> HandleAsync(string companyId, string entityId, DateTime? from, DateTime? end)
        {
            await inputPort.GenerateCustomerFeedbackReportAsync(companyId, entityId, from, end);
            return outputPort.ReportViewModel;
        }
    }
}
