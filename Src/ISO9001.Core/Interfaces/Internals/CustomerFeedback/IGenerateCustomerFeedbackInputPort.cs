namespace ISO9001.Core.Interfaces.Internals.CustomerFeedback;

internal interface IGenerateCustomerFeedbackInputPort
{
    ValueTask GenerateCustomerFeedbackReportAsync(string companyId, string entityId, DateTime? from, DateTime? end);
}
