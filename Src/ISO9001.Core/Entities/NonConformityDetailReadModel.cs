namespace ISO9001.Core.Entities;

public class NonConformityDetailReadModel
{
    public int Id { get; set; }
    public DateTime ReportedAt { get; set; }
    public string ReportedBy { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid NonConformityId { get; set; }
}
