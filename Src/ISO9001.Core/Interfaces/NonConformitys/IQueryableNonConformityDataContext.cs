namespace ISO9001.Core.Interfaces.NonConformitys;

public interface IQueryableNonConformityDataContext
{
    Task<IEnumerable<NonConformityReadModel>> ToNonConformityListAsync(
        Expression<Func<NonConformityReadModel, bool>> filter = null,
        Func<IQueryable<NonConformityReadModel>, IOrderedQueryable<NonConformityReadModel>> orderBy = null);

    Task<IEnumerable<NonConformityDetailReadModel>> ToNonConformityDetailListAsync(
        Expression<Func<NonConformityDetailReadModel, bool>> filter = null,
        Func<IQueryable<NonConformityDetailReadModel>, IOrderedQueryable<NonConformityDetailReadModel>> orderBy = null);
}