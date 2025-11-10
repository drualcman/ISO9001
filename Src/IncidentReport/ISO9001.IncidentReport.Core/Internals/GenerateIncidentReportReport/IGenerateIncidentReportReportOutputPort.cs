using DigitalDoor.Reporting.Entities.ViewModels;

namespace ISO9001.IncidentReport.Core.Internals.GenerateIncidentReportReport
{
    public interface IGenerateIncidentReportReportOutputPort
    {
        public ReportViewModel ReportViewModel { get; }
        Task Handle(IEnumerable<IncidentReportResponse> incidentReportResponses, string companyId);
    }
}
