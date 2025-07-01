namespace ISO9001.Entities.Dtos;
public class NonConformityCreateDetailDto
{
    public Guid EntityId { get; set; }
    public string CompanyId { get; set; }
    public DateTime ReportedAt { get; set; }
    public string ReportedBy { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
}
