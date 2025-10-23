namespace ISO9001.AuditReport.Core.Internals.GenerateAuditReport
{
    internal interface IGenerateAuditReportOutputPort
    {
        public byte[] PdfBytes { get; }

        Task Handle(IEnumerable<NonConformityMaterResponse> nonConformityMaterResponses, IEnumerable<IncidentReportResponse> incidentReportResponses,
            IEnumerable<CustomerFeedbackResponse> customerFeedbackResponses, string entityId, DateTime from, DateTime end);
    }
}
