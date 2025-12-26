using ISO9001.Core.Responses;

namespace ISO9001.Core.Features.Interfaces.Internals.IncidentReport;

public interface IGenerateIncidentReportReportOutputPort
{
    public ReportViewModel ReportViewModel { get; }
    Task Handle(IEnumerable<IncidentReportResponse> incidentReportResponses, string companyId);
}
