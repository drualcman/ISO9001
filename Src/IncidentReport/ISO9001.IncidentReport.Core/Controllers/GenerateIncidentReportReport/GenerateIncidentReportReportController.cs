using DigitalDoor.Reporting.Entities.ViewModels;

namespace ISO9001.IncidentReport.Core.Controllers.GenerateIncidentReportReport
{
    internal class GenerateIncidentReportReportController(
        IGenerateIncidentReportReportInputPort inputPort,
        IGenerateIncidentReportReportOutputPort outputPort): IGenerateIncidentReportReportController
    {
        public async Task<ReportViewModel> HandleAsync(string companyId, string entityId, DateTime? from, DateTime? end)
        {
            await inputPort.GenerateCustomerFeedbackReportAsync(companyId, entityId, from, end);
            return outputPort.ReportViewModel;
        }
    }
}
