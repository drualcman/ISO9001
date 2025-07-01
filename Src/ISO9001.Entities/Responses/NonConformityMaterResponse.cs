namespace ISO9001.Entities.Responses;
public class NonConformityMaterResponse
{
    public Guid Id { get; set; }
    public string EntityId { get; set; }
    public DateTime ReportedAt { get; set; }
    public string AffectedProcess { get; set; }
    public string Cause { get; set; }
    public string Status { get; set; }
    public int DetailsCount { get; set; }
}
