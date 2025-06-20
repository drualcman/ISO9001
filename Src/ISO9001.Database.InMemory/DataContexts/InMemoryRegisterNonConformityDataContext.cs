using ISO9001.Database.InMemory.DataContexts.Entities;
using ISO9001.RegisterNonConformityRepositories.Interfaces;


namespace ISO9001.Database.InMemory.DataContexts
{
    internal class InMemoryRegisterNonConformityDataContext : IRegisterNonConformityDataContext
    {
        private static readonly List<NonConformity> NonConformityList = new();
        private static readonly List<NonConformityDetail> NonConformityDetailsList = new();
        private static int CurrentId = 0;

        public Task AddAsync(RegisterNonConformityRepositories.Entities.NonConformity nonConformityMaster)
        {
            var NonConformityRecord = new NonConformity
            {
                Id = ++CurrentId,
                ReportedAt = nonConformityMaster.ReportedAt,
                EntityId = nonConformityMaster.EntityId,
                CompanyId = nonConformityMaster.CompanyId,
                AffectedProcess = nonConformityMaster.AffectedProcess,
                Status = nonConformityMaster.Status,
                CreatedAt = DateTime.UtcNow
            };

            var NonConformityDetailRecord = new NonConformityDetail
            {
                Id = CurrentId,
                NonConformityId = NonConformityRecord.Id,
                ReportedAt = nonConformityMaster.nonConformityDetails[0].ReportedAt,
                ReportedBy = nonConformityMaster.nonConformityDetails[0].ReportedBy,
                Description = nonConformityMaster.nonConformityDetails[0].Description,
                Cause = nonConformityMaster.nonConformityDetails[0].Cause,
                Status = nonConformityMaster.nonConformityDetails[0].Status,
                CreatedAt = DateTime.UtcNow
            };
            NonConformityList.Add(NonConformityRecord);
            NonConformityDetailsList.Add(NonConformityDetailRecord);
            return Task.CompletedTask;
        }

        public Task SaveChangesAsync()
        {
            return Task.CompletedTask;
        }
    }
}
