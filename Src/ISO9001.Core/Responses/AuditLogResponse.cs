namespace ISO9001.Core.Responses;

public class AuditLogResponse(string logId, string entityId, string action,
    string performedBy, DateTime timeStamp, DateTime createdAt, string details)
{
    public string LogId => logId;
    public string EntityId => entityId;
    public string Action => action;
    public string PerformedBy => performedBy;
    public DateTime TimeStamp => timeStamp;
    public DateTime CreatedAt => createdAt;
    public string Details => details;
}
