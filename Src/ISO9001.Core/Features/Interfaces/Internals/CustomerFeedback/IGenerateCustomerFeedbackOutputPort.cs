using ISO9001.Core.Responses;

namespace ISO9001.Core.Features.Interfaces.Internals.CustomerFeedback
{
    public interface IGenerateCustomerFeedbackOutputPort
    {
        public ReportViewModel ReportViewModel { get; }
        Task Handle(IEnumerable<CustomerFeedbackResponse> customerFeedbackResponses, string companyId);

    }
}
