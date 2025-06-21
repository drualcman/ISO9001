namespace ISO9001.AuditLogs.Repositories.Entities
{
    public class AuditLogReadModel
    {
        public int LogId { get; set; }
        public string EntityId { get; set; }
        public string CompanyId { get; set; }
        public string Action { get; set; }
        public string PerformedBy { get; set; }
        public DateTime Timestamp { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Details { get; set; }
    }
}
