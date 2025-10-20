namespace ISO9001.Database.InMemory.DataContexts.Entities
{
    public class NonConformityDetail
    {
        public int Id { get; set; }
        public DateTime ReportedAt { get; set; }
        public string ReportedBy { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid NonConformityId { get; set; }

    }
}
