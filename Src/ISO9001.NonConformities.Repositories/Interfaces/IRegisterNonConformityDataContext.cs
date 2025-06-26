using ISO9001.NonConformities.Repositories.Entities;

namespace ISO9001.NonConformities.Repositories.Interfaces
{
    public interface IRegisterNonConformityDataContext
    {
        Task AddAsync(NonConformity nonConformityMaster);
        Task SaveChangesAsync();
    }
}
