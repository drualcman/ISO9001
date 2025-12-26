namespace ISO9001.Core.Dtos;

public class NonConformityDto(string entityId, string companyId, DateTime reportedAt,
    string reportedBy, string description, string affectedProcess, string cause, string status)
{
    public string EntityId => entityId;
    public string CompanyId => companyId;
    public DateTime ReportedAt => reportedAt;
    public string ReportedBy => reportedBy;
    public string Description => description;
    public string AffectedProcess => affectedProcess;
    public string Cause => cause;
    public string Status => status;
}
