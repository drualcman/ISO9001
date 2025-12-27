using System.Linq.Expressions;

namespace ISO9001.Database.InMemory.DataContexts.NonConformityDataContext;

internal class InMemoryQueryableNonConformityDataContext(
    InMemoryNonConformityStore dataContext) : IQueryableNonConformityDataContext
{
    public IQueryable<NonConformityReadModel> NonConformities =>
        dataContext.NonConformities
        .Select(NonConformity => new NonConformityReadModel
        {
            Id = NonConformity.Id,
            ReportedAt = NonConformity.ReportedAt,
            EntityId = NonConformity.EntityId,
            CompanyId = NonConformity.CompanyId,
            AffectedProcess = NonConformity.AffectedProcess,
            Cause = NonConformity.Cause,
            Status = NonConformity.Status,
            CreatedAt = NonConformity.CreatedAt
        }).AsQueryable();

    public IQueryable<NonConformityDetailReadModel> NonConformityDetails =>
    dataContext.NonConformityDetails
    .Select(NonConformityDetail => new NonConformityDetailReadModel
    {
        Id = NonConformityDetail.Id,
        ReportedAt = NonConformityDetail.ReportedAt,
        ReportedBy = NonConformityDetail.ReportedBy,
        Description = NonConformityDetail.Description,
        Status = NonConformityDetail.Status,
        CreatedAt = NonConformityDetail.CreatedAt,
        NonConformityId = NonConformityDetail.NonConformityId
    }).AsQueryable();

    public async Task<IEnumerable<NonConformityReadModel>> ToListAsync(
    Expression<Func<NonConformityReadModel, bool>> filter = null,
    Func<IQueryable<NonConformityReadModel>, IOrderedQueryable<NonConformityReadModel>> orderBy = null)
    {
        IQueryable<NonConformityReadModel> query = NonConformities;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (orderBy != null)
        {
            query = orderBy(query);
        }

        var data = query.ToList();
        return await Task.FromResult(data);
    }

    public async Task<IEnumerable<NonConformityDetailReadModel>> ToListAsync(
    Expression<Func<NonConformityDetailReadModel, bool>> filter = null,
    Func<IQueryable<NonConformityDetailReadModel>, IOrderedQueryable<NonConformityDetailReadModel>> orderBy = null)
    {
        IQueryable<NonConformityDetailReadModel> query = NonConformityDetails;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (orderBy != null)
        {
            query = orderBy(query);
        }

        var data = query.ToList();
        return await Task.FromResult(data);
    }
}