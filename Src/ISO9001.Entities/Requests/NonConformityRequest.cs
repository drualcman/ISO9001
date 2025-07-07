namespace ISO9001.Entities.Requests
{
    public class NonConformityRequest
    {
        public string EntityId { get; set; }
        public string CompanyId { get; set; }
        public DateTime ReportedAt { get; set; }
        public string ReportedBy { get; set; }
        public string Description { get; set; }
        public string AffectedProcess { get; set; }
        public string Cause { get; set; }
        public string Status { get; set; }
    }


}
