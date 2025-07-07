using ISO9001.Database.InMemory.DataContexts.Entities;
using ISO9001.NonConformities.Repositories.Entities;
using ISO9001.NonConformities.Repositories.Interfaces;


namespace ISO9001.Database.InMemory.DataContexts.NonConformityDataContext
{
    internal class InMemoryRegisterNonConformityDataContext : IRegisterNonConformityDataContext
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

        public Task AddAsync(NonConformities.Repositories.Entities.NonConformity nonConformityMaster)
        {
            var NonConformityRecord = new DataContexts.Entities.NonConformity
            {
                Id = Guid.NewGuid(),
                ReportedAt = nonConformityMaster.ReportedAt,
                EntityId = nonConformityMaster.EntityId,
                CompanyId = nonConformityMaster.CompanyId,
                AffectedProcess = nonConformityMaster.AffectedProcess,
                Cause = nonConformityMaster.Cause,
                Status = nonConformityMaster.Status,
                CreatedAt = DateTime.UtcNow
            };

            var NonConformityDetailRecord = new DataContexts.Entities.NonConformityDetail
            {
                Id = ++InMemoryNonConformityStore.NonConformityDetailsCurrentId,
                NonConformityId = NonConformityRecord.Id,
                ReportedAt = nonConformityMaster.NonConformityDetails[0].ReportedAt,
                ReportedBy = nonConformityMaster.NonConformityDetails[0].ReportedBy,
                Description = nonConformityMaster.NonConformityDetails[0].Description,
                Status = nonConformityMaster.NonConformityDetails[0].Status,
                CreatedAt = DateTime.UtcNow
            };

            InMemoryNonConformityStore.NonConformities.Add(NonConformityRecord);
            InMemoryNonConformityStore.NonConformityDetails.Add(NonConformityDetailRecord);
            return Task.CompletedTask;
        }

        public Task SaveChangesAsync()
        {
            return Task.CompletedTask;
        }
    }
}
