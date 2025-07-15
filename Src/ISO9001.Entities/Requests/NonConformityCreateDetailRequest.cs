namespace ISO9001.Entities.Requests;
public class NonConformityCreateDetailRequest
{
    public DateTime ReportedAt { get; set; }
    public string NonConformityId { get; set; }
    public string ReportedBy { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
}
