using DigitalDoor.Reporting.Entities.ViewModels;

namespace ISO9001.IncidentReport.Core.Internals.GenerateIncidentReportReport
{
    public interface IGenerateIncidentReportReportController
    {
        Task<ReportViewModel> HandleAsync(string companyId, string entityId, DateTime? from, DateTime? end);

    }
}
