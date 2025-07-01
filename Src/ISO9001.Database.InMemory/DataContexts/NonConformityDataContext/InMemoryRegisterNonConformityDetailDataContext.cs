using ISO9001.NonConformities.Repositories.Entities;
using ISO9001.NonConformities.Repositories.Interfaces;

namespace ISO9001.Database.InMemory.DataContexts.NonConformityDataContext
{
    internal class InMemoryRegisterNonConformityDetailDataContext : IRegisterNonCormityDetailDataContext
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
                Status = NonConformity.Status,
                CreatedAt = NonConformity.CreatedAt
            }).AsQueryable();

        public Task AddAsync(NonConformityDetail nonConformityDetail, string companyId, string entityId)
        {
            var NonConformity = InMemoryNonConformityStore.NonConformities
                .FirstOrDefault(nonConformity =>
                nonConformity.CompanyId == companyId &&
                nonConformity.EntityId == entityId);

            var NonConformityDetailRecord = new DataContexts.Entities.NonConformityDetail
            {
                Id = ++InMemoryNonConformityStore.NonConformityDetailsCurrentId,
                NonConformityId = NonConformity.Id,
                ReportedAt = nonConformityDetail.ReportedAt,
                ReportedBy = nonConformityDetail.ReportedBy,
                Description = nonConformityDetail.Description,
                Cause = nonConformityDetail.Cause,
                Status = nonConformityDetail.Status,
                CreatedAt = DateTime.UtcNow
            };

            InMemoryNonConformityStore.NonConformityDetails.Add(NonConformityDetailRecord);
            return Task.CompletedTask;
        }

        public Task SaveChangesAsync()
        {
            return Task.CompletedTask;
        }
    }
}
