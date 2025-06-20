namespace ISO9001.Database.InMemory.DataContexts.Entities
{
    public class NonConformity
    {
        public int Id { get; set; }
        public DateTime ReportedAt { get; set; }
        public string EntityId { get; set; }
        public string CompanyId { get; set; }
        public string AffectedProcess { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set;}
    }
}
