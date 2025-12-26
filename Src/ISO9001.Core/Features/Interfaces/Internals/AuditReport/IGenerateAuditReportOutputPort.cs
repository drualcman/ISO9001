using ISO9001.Core.Responses;

namespace ISO9001.Core.Features.Interfaces.Internals.AuditReport;

internal interface IGenerateAuditReportOutputPort
{
    public ReportViewModel ReportViewModel { get; }
    Task Handle(IEnumerable<NonConformityMaterResponse> nonConformityMaterResponses, IEnumerable<IncidentReportResponse> incidentReportResponses,
        IEnumerable<CustomerFeedbackResponse> customerFeedbackResponses, string entityId);
}
