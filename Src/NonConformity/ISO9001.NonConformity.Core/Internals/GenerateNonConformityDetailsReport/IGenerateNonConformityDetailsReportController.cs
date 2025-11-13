namespace ISO9001.NonConformity.Core.Internals.GenerateNonConformityDetailsReport
{
    public interface IGenerateNonConformityDetailsReportController
    {
        Task<ReportViewModel> HandleAsync(string companyId, string nonConformityId, DateTime? from, DateTime? end);
    }
}
