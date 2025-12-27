namespace ISO9001.Core.Interfaces.NonConformitys;

public interface IQueryableNonConformityDataContext
{
    Task<IEnumerable<NonConformityReadModel>> ToListAsync(
        Expression<Func<NonConformityReadModel, bool>> filter = null,
        Func<IQueryable<NonConformityReadModel>, IOrderedQueryable<NonConformityReadModel>> orderBy = null);

    Task<IEnumerable<NonConformityDetailReadModel>> ToListAsync(
        Expression<Func<NonConformityDetailReadModel, bool>> filter = null,
        Func<IQueryable<NonConformityDetailReadModel>, IOrderedQueryable<NonConformityDetailReadModel>> orderBy = null);
}