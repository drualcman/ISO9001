namespace ISO9001.Core.Features.Interfaces.Internals.CustomerFeedback
{
    public interface IGenerateCustomerFeedbackInputPort
    {
        ValueTask GenerateCustomerFeedbackReportAsync(string companyId, string entityId, DateTime? from, DateTime? end);
    }
}
