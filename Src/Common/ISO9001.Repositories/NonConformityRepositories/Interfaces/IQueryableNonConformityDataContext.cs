using ISO9001.Repositories.NonConformityRepositories.Entities;

namespace ISO9001.Repositories.NonConformityRepositories.Interfaces
{
    public interface IQueryableNonConformityDataContext
    {
        IQueryable<NonConformityReadModel> NonConformities { get; }

        IQueryable<NonConformityDetailReadModel> NonConformityDetails { get; }

        Task<IEnumerable<NonConformityReadModel>> ToListAsync(
            IQueryable<NonConformityReadModel> queryable);

        Task<IEnumerable<NonConformityDetailReadModel>> ToListAsync(
            IQueryable<NonConformityDetailReadModel> queryable);
    }
}

