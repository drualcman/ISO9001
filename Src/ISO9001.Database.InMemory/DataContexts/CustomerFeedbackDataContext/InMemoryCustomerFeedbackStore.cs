using ISO9001.Database.InMemory.DataContexts.Entities;

namespace ISO9001.Database.InMemory.DataContexts.CustomerFeedbackDataContext
{
    internal class InMemoryCustomerFeedbackStore
    {
        public List<CustomerFeedback> CustomerFeedbacks { get; } = new();
        public int CurrentId { get; set; }
    }
}
