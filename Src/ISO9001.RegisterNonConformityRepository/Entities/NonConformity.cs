namespace ISO9001.RegisterNonConformityRepositories.Entities
{
    public class NonConformity
    {
        public string EntityId { get; set; }
        public string CompanyId { get; set; }
        public string AffectedProcess { get; set; }
        public string Status { get; set; }
        public DateTime ReportedAt { get; set; }
        public List<NonConformityDetail> nonConformityDetails { get; set; }

    }
}
