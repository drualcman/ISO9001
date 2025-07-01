using System.Diagnostics.Metrics;

namespace ISO9001.Entities.Responses
{
    public class NonConformityDetailResponse(DateTime reportedAt, string reportedBy, string description, string cause, string status)
    {
        public DateTime ReportedAt => reportedAt;
        public string ReportedBy => reportedBy;
        public string Description => description;
        public string Cause => cause;
        public string Status => status;
    }
}
