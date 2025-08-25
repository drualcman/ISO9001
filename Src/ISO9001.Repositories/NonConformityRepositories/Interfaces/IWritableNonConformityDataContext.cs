using ISO9001.Repositories.NonConformityRepositories.Entities;

namespace ISO9001.Repositories.NonConformityRepositories.Interfaces
{
    public interface IWritableNonConformityDataContext
    {
        Task AddNonConformityAsync(NonConformity nonConformityMaster);
        Task AddNonConformityDetailAsync(NonConformityDetail nonConformityDetail, Guid id);
        Task UpdateNonConformityAsync(NonConformityReadModel nonConformity);
        Task SaveChangesAsync();
    }
}

