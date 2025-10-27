namespace ISO9001.Database.InMemory.DataContexts.NonConformityDataContext
{
    internal class InMemoryWritableNonConformityDataContext(
        InMemoryNonConformityStore dataContext) : IWritableNonConformityDataContext
    {
        public Task AddNonConformityAsync(Repositories.NonConformityRepositories.Entities.NonConformity nonConformityMaster)
        {
            var NonConformityRecord = new DataContexts.Entities.NonConformity
            {
                Id = nonConformityMaster.Id,
                ReportedAt = nonConformityMaster.ReportedAt,
                EntityId = nonConformityMaster.EntityId,
                CompanyId = nonConformityMaster.CompanyId,
                AffectedProcess = nonConformityMaster.AffectedProcess,
                Cause = nonConformityMaster.Cause,
                Status = nonConformityMaster.Status,
                CreatedAt = DateTime.UtcNow
            };
            dataContext.NonConformities.Add(NonConformityRecord);
            return Task.CompletedTask;
        }

        public Task AddNonConformityDetailAsync(Repositories.NonConformityRepositories.Entities.NonConformityDetail nonConformityDetail, Guid id)
        {
            var NonConformity = dataContext.NonConformities
                .FirstOrDefault(nonConformity =>
                nonConformity.Id == id);

            var NonConformityDetailRecord = new DataContexts.Entities.NonConformityDetail
            {
                Id = ++dataContext.NonConformityDetailsCurrentId,
                NonConformityId = NonConformity.Id,
                ReportedAt = nonConformityDetail.ReportedAt,
                ReportedBy = nonConformityDetail.ReportedBy,
                Description = nonConformityDetail.Description,
                Status = nonConformityDetail.Status,
                CreatedAt = DateTime.UtcNow
            };

            dataContext.NonConformityDetails.Add(NonConformityDetailRecord);
            return Task.CompletedTask;
        }

        public Task UpdateNonConformityAsync(NonConformityReadModel nonConformityUpdated)
        {
            var NonConformitRecord = dataContext.NonConformities
                .FirstOrDefault(NonConformity => NonConformity.Id == nonConformityUpdated.Id);

            NonConformitRecord.EntityId = nonConformityUpdated.EntityId;
            NonConformitRecord.CompanyId = nonConformityUpdated.CompanyId;
            NonConformitRecord.AffectedProcess = nonConformityUpdated.AffectedProcess;
            NonConformitRecord.Cause = nonConformityUpdated.Cause;
            NonConformitRecord.Status = nonConformityUpdated.Status;

            return Task.CompletedTask;
        }


        public Task SaveChangesAsync()
        {
            return Task.CompletedTask;
        }
    }
}

