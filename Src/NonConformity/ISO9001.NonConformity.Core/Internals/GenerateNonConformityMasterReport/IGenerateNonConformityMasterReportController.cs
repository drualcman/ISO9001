namespace ISO9001.NonConformity.Core.Internals.GenerateNonConformityMasterReport
{
    public interface IGenerateNonConformityMasterReportController
    {
        Task<ReportViewModel> HandleAsync(string companyId, string entityId, DateTime? from, DateTime? end);
    }
}
