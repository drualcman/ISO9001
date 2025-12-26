namespace ISO9001.Core.Responses;

public class CustomerFeedbackResponse(string entityId, string customerId, int rating, DateTime reportedAt)
{
    public string EntityId => entityId;
    public string CustomerId => customerId;
    public int Rating => rating;
    public DateTime ReportedAt => reportedAt;
}
