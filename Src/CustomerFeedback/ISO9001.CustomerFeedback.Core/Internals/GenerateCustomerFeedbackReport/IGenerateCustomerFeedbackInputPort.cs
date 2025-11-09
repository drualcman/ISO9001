namespace ISO9001.CustomerFeedback.Core.Internals.GenerateCustomerFeedbackReport
{
    public interface IGenerateCustomerFeedbackInputPort
    {
        ValueTask GenerateCustomerFeedbackReportAsync(string companyId, string entityId, DateTime? from, DateTime? end);
    }
}
