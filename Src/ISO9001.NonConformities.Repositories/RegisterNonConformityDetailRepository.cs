using ISO9001.Entities.Dtos;
using ISO9001.NonConformities.Repositories.Entities;
using ISO9001.NonConformities.Repositories.Interfaces;
using ISO9001.RegisterNonConformityDetail.BusinessObjects.Interfaces;

namespace ISO9001.NonConformities.Repositories
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
                Status = nonConformityDetail.Status,
                ReportedAt = nonConformityDetail.ReportedAt
            };

            await writableNonConformityDataContext.AddNonConformityDetailAsync(NewDetail, nonConformityDetail.EntityId);
        }
 

        public Task UpdateStatusNonConformityMasterAsync(Guid entityId, string status)
        {
            NonConformityReadModel NonConformityMaster = queryNonConformityDataContext.NonConformities
                .FirstOrDefault(nonConformity =>
                    nonConformity.Id == entityId);

            NonConformityMaster.Status = status;
            writableNonConformityDataContext.UpdateNonConformityAsync(NonConformityMaster);
            return Task.CompletedTask;
        }

        public Task SaveChangesAsync() => writableNonConformityDataContext.SaveChangesAsync();
    }
}
