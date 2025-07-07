using ISO9001.NonConformities.Repositories.Entities;

namespace ISO9001.NonConformities.Repositories.Interfaces
{
    public interface IRegisterNonCormityDetailDataContext
    {
        IQueryable<NonConformityReadModel> NonConformities { get; }

        Task AddAsync(NonConformityDetail nonConformityDetail, Guid id);
        Task UpdateNonConformityAsync(NonConformityReadModel nonConformity);
        Task SaveChangesAsync();

    }
}
