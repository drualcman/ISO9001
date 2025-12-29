namespace ISO9001.Core.Entities;

public class CustomerFeedbackReadModel
{
    public string Id { get; set; }
    public string EntityId { get; set; }
    public string CompanyId { get; set; }
    public string CustomerId { get; set; }
    public int Rating { get; set; }
    public string Comments { get; set; }
    public DateTime ReportedAt { get; set; }
    public DateTime CreatedAt { get; set; }
}
