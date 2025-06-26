using ISO9001.Database.InMemory.DataContexts.Entities;
using ISO9001.NonConformities.Repositories.Interfaces;


namespace ISO9001.Database.InMemory.DataContexts.NonConformityDataContext
{
    internal class InMemoryRegisterNonConformityDataContext : IRegisterNonConformityDataContext
    {

        public Task AddAsync(NonConformities.Repositories.Entities.NonConformity nonConformityMaster)
        {
            var NonConformityRecord = new NonConformity
            {
                Id = ++InMemoryNonConformityStore.CurrentId,
                ReportedAt = nonConformityMaster.ReportedAt,
                EntityId = nonConformityMaster.EntityId,
                CompanyId = nonConformityMaster.CompanyId,
                AffectedProcess = nonConformityMaster.AffectedProcess,
                Status = nonConformityMaster.Status,
                CreatedAt = DateTime.UtcNow
            };

            var NonConformityDetailRecord = new NonConformityDetail
            {
                Id = InMemoryNonConformityStore.CurrentId,
                NonConformityId = NonConformityRecord.Id,
                ReportedAt = nonConformityMaster.NonConformityDetails[0].ReportedAt,
                ReportedBy = nonConformityMaster.NonConformityDetails[0].ReportedBy,
                Description = nonConformityMaster.NonConformityDetails[0].Description,
                Cause = nonConformityMaster.NonConformityDetails[0].Cause,
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
