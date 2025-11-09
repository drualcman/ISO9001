using DigitalDoor.Reporting.Entities.ViewModels;

namespace ISO9001.CustomerFeedback.Core.Internals.GenerateCustomerFeedbackReport
{
    public interface IGenerateCustomerFeedbackOutputPort
    {
        public ReportViewModel ReportViewModel { get; }
        Task Handle(IEnumerable<CustomerFeedbackResponse> customerFeedbackResponses, string companyId);
        
    }
}
