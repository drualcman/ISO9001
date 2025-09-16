using ISO9001.Repositories.NonConformityRepositories.Entities;
using ISO9001.Repositories.NonConformityRepositories.Interfaces;

namespace ISO9001.Database.InMemory.DataContexts.NonConformityDataContext
{
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

        public async Task<IEnumerable<NonConformityReadModel>> ToListAsync(IQueryable<NonConformityReadModel> queryable)
            => await Task.FromResult(queryable.ToList());

        public async Task<IEnumerable<NonConformityDetailReadModel>> ToListAsync(IQueryable<NonConformityDetailReadModel> queryable)
            => await Task.FromResult(queryable.ToList());
    }
}
