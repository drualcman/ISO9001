namespace ISO9001.Core.Entities;

public class NonConformityReadModel
{
    public Guid Id { get; set; }
    public DateTime ReportedAt { get; set; }
    public string EntityId { get; set; }
    public string CompanyId { get; set; }
    public string AffectedProcess { get; set; }
    public string Cause { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }
}
