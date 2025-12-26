namespace ISO9001.Core.Interfaces.Internals.AuditReport;

internal interface IGenerateAuditReportOutputPort
{
    public ReportViewModel ReportViewModel { get; }
    Task Handle(IEnumerable<NonConformityMaterResponse> nonConformityMaterResponses, IEnumerable<IncidentReportResponse> incidentReportResponses,
        IEnumerable<CustomerFeedbackResponse> customerFeedbackResponses, string entityId);
}
