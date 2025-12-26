namespace ISO9001.Core.Interfaces.NonConformitys;

public interface IGenerateNonConformityMasterReportController
{
    Task<ReportViewModel> HandleAsync(string companyId, string entityId, DateTime? from, DateTime? end);
}
