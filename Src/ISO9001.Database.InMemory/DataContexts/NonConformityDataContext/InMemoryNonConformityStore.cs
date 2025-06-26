using ISO9001.Database.InMemory.DataContexts.Entities;

namespace ISO9001.Database.InMemory.DataContexts.NonConformityDataContext
{
    internal static class InMemoryNonConformityStore
    {
        public static List<NonConformity> NonConformities { get; } = new();
        public static List<NonConformityDetail> NonConformityDetails { get; } = new();
        public static int CurrentId { get; set; }
    }
}
