using ISO9001.NonConformities.Repositories.Entities;

namespace ISO9001.NonConformities.Repositories.Interfaces
{
    public interface IGetAllNonConformitiesDataContext
    {
        IQueryable<NonConformityReadModel> NonConformities { get; }
        IQueryable<NonConformityDetailReadModel> NonConformityDetails { get; }
        Task<IEnumerable<ReturnType>> ToListAsync<ReturnType>(
            IQueryable<ReturnType> queryable);
    }
}
