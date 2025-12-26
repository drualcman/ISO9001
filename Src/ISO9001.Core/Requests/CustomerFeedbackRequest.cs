namespace ISO9001.Core.Requests;

public class CustomerFeedbackRequest
{
    public string EntityId { get; set; }
    public string CompanyId { get; set; }
    public string CustomerId { get; set; }
    public int Rating { get; set; }
    public string Comments { get; set; }
    public DateTime ReportedAt { get; set; }
}
