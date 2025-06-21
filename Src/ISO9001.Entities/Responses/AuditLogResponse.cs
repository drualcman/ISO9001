﻿namespace ISO9001.Entities.Responses
{
    public class AuditLogResponse(int logId, string entityId, string action,
        string performedBy, DateTime timeStamp, DateTime createdAt, string details)
    {
        public int LogId => logId;
        public string EntityId => entityId;
        public string Action => action;
        public string PerformedBy => performedBy;
        public DateTime TimeStamp => timeStamp;
        public DateTime CreatedAt => createdAt;
        public string Details => details;
    }
}
