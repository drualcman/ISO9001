namespace ISO9001.NonConformity.Core.Internals.GenerateNonConformityMasterReport
{
    public interface IGenerateNonConformityMasterReportOutputPort
    {
        public ReportViewModel ReportViewModel { get; }
        Task Handle(IEnumerable<NonConformityMaterResponse> nonConformityResponses, string companyId);
    }
}
