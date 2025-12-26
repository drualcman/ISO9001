namespace ISO9001.Core.Interfaces.NonConformitys;

public interface IGenerateNonConformityDetailsReportController
{
    Task<ReportViewModel> HandleAsync(string companyId, string nonConformityId, DateTime? from, DateTime? end);
}
