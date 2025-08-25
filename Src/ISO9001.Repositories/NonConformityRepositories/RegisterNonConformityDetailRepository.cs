using ISO9001.Entities.Dtos;
using ISO9001.RegisterNonConformityDetail.BusinessObjects.Interfaces;
using ISO9001.Repositories.NonConformityRepositories.Entities;
using ISO9001.Repositories.NonConformityRepositories.Interfaces;

namespace ISO9001.Repositories.NonConformityRepositories
{
    internal class RegisterNonConformityDetailRepository(
        IQueryableNonConformityDataContext queryNonConformityDataContext,
        IWritableNonConformityDataContext writableNonConformityDataContext): IRegisterNonConformityDetailRepository
    {

        public Task<bool> NonConformityExistsByGuidAsync(Guid entityId)
        {
            NonConformityReadModel NonConformityMaster = queryNonConformityDataContext.NonConformities
                .FirstOrDefault(nonConformity =>
                    nonConformity.Id == entityId);

            bool Exists = NonConformityMaster != null;
            return Task.FromResult(Exists);
        }

        public async Task RegisterNonConformityDetailAsync(NonConformityCreateDetailDto nonConformityDetail)
        {

            NonConformityDetail NewDetail = new NonConformityDetail
            {
                ReportedBy = nonConformityDetail.ReportedBy,
                Description = nonConformityDetail.Description,
                Status = nonConformityDetail.Status.ToLower(),
                ReportedAt = nonConformityDetail.ReportedAt
            };

            await writableNonConformityDataContext.AddNonConformityDetailAsync(NewDetail, nonConformityDetail.EntityId);
        }
 

        public Task UpdateStatusNonConformityMasterAsync(Guid entityId, string status)
        {
            NonConformityReadModel NonConformityMaster = queryNonConformityDataContext.NonConformities
                .FirstOrDefault(nonConformity =>
                    nonConformity.Id == entityId);

            NonConformityMaster.Status = status.ToLower();
            writableNonConformityDataContext.UpdateNonConformityAsync(NonConformityMaster);
            return Task.CompletedTask;
        }

        public Task SaveChangesAsync() => writableNonConformityDataContext.SaveChangesAsync();
    }
}
