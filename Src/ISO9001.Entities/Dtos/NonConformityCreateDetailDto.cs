namespace ISO9001.Entities.Dtos;
public class NonConformityCreateDetailDto(Guid entityId, string companyId, DateTime reportedAt,
    string reportedBy, string description, string status)
{
    public Guid EntityId => entityId;
    public string CompanyId => companyId;
    public DateTime ReportedAt => reportedAt;
    public string ReportedBy => reportedBy;
    public string Description => description;
    public string Status => status;
}
