namespace ISO9001.Core.Interfaces.Internals.CustomerFeedback;

internal interface IGenerateCustomerFeedbackOutputPort
{
    public ReportViewModel ReportViewModel { get; }
    Task Handle(IEnumerable<CustomerFeedbackResponse> customerFeedbackResponses, string companyId);

}
