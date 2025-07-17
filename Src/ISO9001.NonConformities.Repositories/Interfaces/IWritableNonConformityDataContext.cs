using ISO9001.NonConformities.Repositories.Entities;

namespace ISO9001.NonConformities.Repositories.Interfaces
{
    public interface IWritableNonConformityDataContext
    {
        Task AddNonConformityAsync(NonConformity nonConformityMaster);
        Task AddNonConformityDetailAsync(NonConformityDetail nonConformityDetail, Guid id);
        Task UpdateNonConformityAsync(NonConformityReadModel nonConformity);
        Task SaveChangesAsync();
    }
}

