namespace ISO9001.Entities.Responses
{
    public class AuditEventResponse(string id, string entityId, DateTime timeStamp,
        string eventType, string description, string responsibleUser)
    {
        public string Id => id;
        public string EntityId => entityId;
        public DateTime TimeStamp => timeStamp;
        public string EventType => eventType;
        public string Description => description;
        public string ResponsibleUser => responsibleUser;
    }
}
