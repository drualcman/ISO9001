using ISO9001.Database.InMemory.DataContexts.Entities;

namespace ISO9001.Database.InMemory.DataContexts.CustomerFeedbackDataContext
{
    internal class InMemoryCustomerFeedbackStore
    {
        public static List<CustomerFeedback> CustomerFeedbacks { get; } = new();
        public static int CurrentId { get; set; }
    }
}
