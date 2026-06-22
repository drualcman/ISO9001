namespace ISO9001.Core.Interfaces.CustomerFeedbacks;

public interface IAnalyzeCustomerFeedbackQuery
{
    Task<AnalyzeFeedbackResponse> HandleAsync(string id, string entityId, DateTime? from, DateTime? end);
}
