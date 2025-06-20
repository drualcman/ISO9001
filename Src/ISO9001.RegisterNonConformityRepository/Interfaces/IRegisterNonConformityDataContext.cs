using ISO9001.RegisterNonConformityRepositories.Entities;

namespace ISO9001.RegisterNonConformityRepositories.Interfaces
{
    public interface IRegisterNonConformityDataContext
    {
        Task AddAsync(NonConformity nonConformityMaster);
        Task SaveChangesAsync();
    }
}
