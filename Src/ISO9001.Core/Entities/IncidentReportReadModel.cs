namespace ISO9001.Core.Entities
{
    public class IncidentReportReadModel
    {
        public string Id { get; set; }
        public string CompanyId { get; set; }
        public string EntityId { get; set; }
        public DateTime ReportedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
        public string AffectedProcess { get; set; }
        public string Severity { get; set; }
        public string Data { get; set; }
    }
}
