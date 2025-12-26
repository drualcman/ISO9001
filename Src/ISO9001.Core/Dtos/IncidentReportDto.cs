namespace ISO9001.Core.Dtos;

public class IncidentReportDto(string companyId, string entityId, DateTime reportedAt,
    string userId, string description, string affectedProcess, string severity, string data)
{
    public string CompanyId => companyId;
    public string EntityId => entityId;
    public DateTime ReportedAt => reportedAt;
    public string UserId => userId;
    public string Description => description;
    public string AffectedProcess => affectedProcess;
    public string Severity => severity;
    public string Data => data;
}
