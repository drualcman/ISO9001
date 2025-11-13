namespace ISO9001.NonConformity.Core.Internals.GenerateNonConformityMasterReport
{
    internal interface IGenerateNonConformityMasterReportOutputPort
    {
        public ReportViewModel ReportViewModel { get; }
        Task Handle(IEnumerable<NonConformityMaterResponse> nonConformityResponses, string companyId);
    }
}
