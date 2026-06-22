namespace ISO9001.Core.Responses;

public class AnalyzeFeedbackResponse(
    double averageRating, int totalCount,
    Dictionary<int, int> ratingsByValue, List<string> recentComments)
{
    public double AverageRating => averageRating;
    public int TotalCount => totalCount;
    public Dictionary<int, int> RatingsByValue => ratingsByValue;
    public List<string> RecentComments => recentComments;
}
