namespace ISO9001.Core.Interfaces.CustomerFeedbacks;

public interface IGenerateCustomerFeedbackReport
{
    Task<ReportViewModel> HandleAsync(string companyId, string entityId, DateTime? from, DateTime? end);
}
