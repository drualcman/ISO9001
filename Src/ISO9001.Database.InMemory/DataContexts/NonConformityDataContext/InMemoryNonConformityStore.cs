using ISO9001.Database.InMemory.DataContexts.Entities;

namespace ISO9001.Database.InMemory.DataContexts.NonConformityDataContext
{
    internal class InMemoryNonConformityStore
    {
        public List<NonConformity> NonConformities { get; } = new();
        public List<NonConformityDetail> NonConformityDetails { get; } = new();
        public int NonConformityDetailsCurrentId { get; set; }

    }
}
