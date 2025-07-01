namespace ISO9001.Entities.Responses
{
    public  class NonConformityResponse(string entityId, DateTime repotedAt,
        string affectedProcess, string status, List<NonConformityDetailResponse> details)
    {
        public string EntityId => entityId;
        public DateTime ReportedAt => repotedAt;
        public string AffectedProcess => affectedProcess;
        public string Status => status;
        public List<NonConformityDetailResponse> Details => details;

    }
}
