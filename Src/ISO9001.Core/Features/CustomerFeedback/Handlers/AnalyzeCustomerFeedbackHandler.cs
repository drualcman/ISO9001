namespace ISO9001.Core.Features.CustomerFeedback.Handlers;

internal class AnalyzeCustomerFeedbackHandler(
    IQueryableCustomerFeedbackRepository repository) : IAnalyzeCustomerFeedbackQuery
{
    public async Task<AnalyzeFeedbackResponse> HandleAsync(string id, string entityId, DateTime? from, DateTime? end)
    {
        DateTime UtcFrom = from != null ? from.Value.Date
            : DateTime.UtcNow.Date.AddDays(-30);

        DateTime UtcEnd = end != null ? end.Value.Date.AddDays(1).AddTicks(-1)
            : DateTime.UtcNow.Date.AddDays(1).AddTicks(-1);

        var CustomerFeedbacks = (await repository.GetCustomerFeedbacksForAnalysisAsync(id, entityId, UtcFrom, UtcEnd))
            .ToList();

        int TotalCount = CustomerFeedbacks.Count;

        double AverageRating = TotalCount > 0
            ? CustomerFeedbacks.Average(CustomerFeedback => CustomerFeedback.Rating)
            : 0;

        Dictionary<int, int> RatingsByValue = CustomerFeedbacks
            .GroupBy(CustomerFeedback => CustomerFeedback.Rating)
            .ToDictionary(Group => Group.Key, Group => Group.Count());

        List<string> RecentComments = CustomerFeedbacks
            .OrderByDescending(CustomerFeedback => CustomerFeedback.ReportedAt)
            .Where(CustomerFeedback => !string.IsNullOrWhiteSpace(CustomerFeedback.Comments))
            .Select(CustomerFeedback => CustomerFeedback.Comments)
            .Take(5)
            .ToList();

        return new AnalyzeFeedbackResponse(AverageRating, TotalCount, RatingsByValue, RecentComments);
    }
}
