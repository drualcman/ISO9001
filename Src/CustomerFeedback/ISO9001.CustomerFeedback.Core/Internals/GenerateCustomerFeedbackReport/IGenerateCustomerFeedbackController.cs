using DigitalDoor.Reporting.Entities.ViewModels;

namespace ISO9001.CustomerFeedback.Core.Internals.GenerateCustomerFeedbackReport
{
    public interface IGenerateCustomerFeedbackController
    {
        Task<ReportViewModel> HandleAsync(string companyId, string entityId, DateTime? from, DateTime? end);
    }
}
