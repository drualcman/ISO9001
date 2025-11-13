namespace ISO9001.NonConformity.Core.Internals.GenerateNonConformityDetailsReport
{
    internal interface IGenerateNonConformityDetailsReportOutputPort
    {
        public ReportViewModel ReportViewModel { get; }
        Task Handle(IEnumerable<NonConformityDetailResponse> nonConformityDetailsResponses, string companyId);
    }
}
