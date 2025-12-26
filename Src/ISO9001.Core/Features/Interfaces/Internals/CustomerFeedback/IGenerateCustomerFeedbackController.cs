namespace ISO9001.Core.Features.Interfaces.Internals.CustomerFeedback
{
    public interface IGenerateCustomerFeedbackController
    {
        Task<ReportViewModel> HandleAsync(string companyId, string entityId, DateTime? from, DateTime? end);
    }
}
