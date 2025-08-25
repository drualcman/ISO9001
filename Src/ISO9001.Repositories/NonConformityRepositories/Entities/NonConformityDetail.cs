namespace ISO9001.Repositories.NonConformityRepositories.Entities
{
    public class NonConformityDetail
    {
        public string ReportedBy { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime ReportedAt { get; set; }
    }
}
