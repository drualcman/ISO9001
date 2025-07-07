using ISO9001.NonConformities.Repositories.Entities;
using ISO9001.NonConformities.Repositories.Interfaces;

namespace ISO9001.Database.InMemory.DataContexts.NonConformityDataContext
{
    internal class InMemoryGetNonConformityByEntityIdDataContext : IGetNonConformityByEntityIdDataContext
    {
        public IQueryable<NonConformityReadModel> NonConformities =>
            InMemoryNonConformityStore.NonConformities
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
            InMemoryNonConformityStore.NonConformityDetails
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

        public async Task<IEnumerable<ReturnType>> ToListAsync<ReturnType>(IQueryable<ReturnType> queryable)
            => await Task.FromResult(queryable.ToList());
    }
}
