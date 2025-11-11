namespace ISO9001.NonConformity.Core.Internals.GenerateNonConformityDetailsReport
{
    public interface IGenerateNonConformityDetailsReportInputPort
    {
        ValueTask GenerateCustomerFeedbackReportAsync(string companyId, string entityId, DateTime? from, DateTime? end);
    }
}
