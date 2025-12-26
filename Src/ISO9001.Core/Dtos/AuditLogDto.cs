namespace ISO9001.Core.Dtos;

public class AuditLogDto(string entityId, string companyId, string action,
    string performedBy, DateTime timestamp, string details, string data)
{
    public string EntityId => entityId;
    public string CompanyId => companyId;
    public string Action => action;
    public string PerformedBy => performedBy;
    public DateTime Timestamp => timestamp;
    public string Details => details;
    public string Data => data;
}
