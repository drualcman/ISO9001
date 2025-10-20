namespace ISO9001.Database.InMemory.DataContexts.NonConformityDataContext
{
    internal class InMemoryNonConformityStore
    {
        public List<Entities.NonConformity> NonConformities { get; } = new();
        public List<Entities.NonConformityDetail> NonConformityDetails { get; } = new();
        public int NonConformityDetailsCurrentId { get; set; }

    }
}
