namespace ISO9001.Database.InMemory.DataContexts.Entities
{
    public class CustomerFeedback
    {
        public int Id { get; set; }
        public string EntityId { get; set; }
        public string CompanyId { get; set; }
        public string CustomerId { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }
        public DateTime ReportedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
