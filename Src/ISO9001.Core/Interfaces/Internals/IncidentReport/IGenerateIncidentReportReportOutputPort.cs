namespace ISO9001.Core.Interfaces.Internals.IncidentReport;

internal interface IGenerateIncidentReportReportOutputPort
{
    public ReportViewModel ReportViewModel { get; }
    Task Handle(IEnumerable<IncidentReportResponse> incidentReportResponses, string companyId);
}
