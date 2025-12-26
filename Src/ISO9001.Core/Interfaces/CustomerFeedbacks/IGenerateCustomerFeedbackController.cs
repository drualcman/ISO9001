namespace ISO9001.Core.Interfaces.CustomerFeedbacks;

public interface IGenerateCustomerFeedbackController
{
    Task<ReportViewModel> HandleAsync(string companyId, string entityId, DateTime? from, DateTime? end);
}
