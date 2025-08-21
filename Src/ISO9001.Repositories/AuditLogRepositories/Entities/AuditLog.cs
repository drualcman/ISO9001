namespace ISO9001.Repositories.AuditLogRepositories.Entities
{
    public class AuditLog
    {
        public string EntityId { get; set; }
        public string CompanyId { get; set; }
        public string Action { get; set; }
        public string PerformedBy { get; set; }
        public DateTime Timestamp { get; set; }
        public string Details { get; set; }
        public string Data { get; set; }
    }
}
