namespace ISO9001.Entities.Responses
{
    public  class NonConformityResponse(string entityId, DateTime repotedAt, string reportedBy,
        string description, string affectedProcess, string cause, string status)
    {
        public string EntityId => entityId;
        public DateTime ReportedAt => repotedAt;
        public string ReportedBy => reportedBy;
        public string Description => description;
        public string AffectedProcess => affectedProcess;
        public string Cause => cause;
        public string Status => status;
    }
}
