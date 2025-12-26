namespace ISO9001.Core.Interfaces.Internals.NonConformity;

internal interface IGenerateNonConformityMasterReportOutputPort
{
    public ReportViewModel ReportViewModel { get; }
    Task Handle(IEnumerable<NonConformityMaterResponse> nonConformityResponses, string companyId);
}
