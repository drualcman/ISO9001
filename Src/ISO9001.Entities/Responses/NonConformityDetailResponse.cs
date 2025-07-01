namespace ISO9001.Entities.Responses
{
    public class NonConformityDetailResponse(DateTime reportedAt, string reportedBy, string description, string status)
    {
        public DateTime ReportedAt => reportedAt;
        public string ReportedBy => reportedBy;
        public string Description => description;
        public string Status => status;
    }
}
