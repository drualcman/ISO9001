namespace ISO9001.Core.Interfaces.Internals.NonConformity;

internal interface IGenerateNonConformityDetailsReportOutputPort
{
    public ReportViewModel ReportViewModel { get; }
    Task Handle(IEnumerable<NonConformityDetailResponse> nonConformityDetailsResponses, string companyId);
}
