namespace ISO9001.Core.Features.Interfaces.Internals.NonConformity;

public interface IGenerateNonConformityDetailsReportController
{
    Task<ReportViewModel> HandleAsync(string companyId, string nonConformityId, DateTime? from, DateTime? end);
}
