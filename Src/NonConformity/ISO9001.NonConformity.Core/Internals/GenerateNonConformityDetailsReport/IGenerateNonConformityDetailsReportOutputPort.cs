namespace ISO9001.NonConformity.Core.Internals.GenerateNonConformityDetailsReport
{
    public interface IGenerateNonConformityDetailsReportOutputPort
    {
        public ReportViewModel ReportViewModel { get; }
        Task Handle(IEnumerable<NonConformityDetailResponse> nonConformityDetailsRresponses, string companyId);
    }
}
