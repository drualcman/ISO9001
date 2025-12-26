namespace ISO9001.Core.Interfaces
{
    public interface IWritableNonConformityDataContext
    {
        Task AddNonConformityAsync(NonConformity nonConformityMaster);
        Task AddNonConformityDetailAsync(NonConformityDetail nonConformityDetail, Guid id);
        Task UpdateNonConformityAsync(NonConformityReadModel nonConformity);
        Task SaveChangesAsync();
    }
}

