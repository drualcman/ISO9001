using ISO9001.Entities.Dtos;
using ISO9001.NonConformities.Repositories.Entities;
using ISO9001.NonConformities.Repositories.Interfaces;
using ISO9001.RegisterNonConformityDetail.BusinessObjects.Interfaces;

namespace ISO9001.NonConformities.Repositories
{
    internal class RegisterNonConformityDetailRepository(
        IRegisterNonCormityDetailDataContext dataContext): IRegisterNonConformityDetailRepository
    {

        public Task<bool> NonConformityExistsByGuidAsync(Guid entityId)
        {
            NonConformityReadModel NonConformityMaster = dataContext.NonConformities
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

            await dataContext.AddAsync(NewDetail, nonConformityDetail.EntityId);
        }

        public Task SaveChangesAsync() => dataContext.SaveChangesAsync();

        public Task UpdateStatusNonConformityMasterAsync(Guid entityId, string status)
        {
            NonConformityReadModel NonConformityMaster = dataContext.NonConformities
                .FirstOrDefault(nonConformity =>
                    nonConformity.Id == entityId);

            NonConformityMaster.Status = status;
            dataContext.UpdateNonConformityAsync(NonConformityMaster);
            return Task.CompletedTask;
        }
    }
}
