namespace ISO9001.Core.Features.Interfaces.Internals.NonConformity;

public interface IGenerateNonConformityMasterReportController
{
    Task<ReportViewModel> HandleAsync(string companyId, string entityId, DateTime? from, DateTime? end);
}
