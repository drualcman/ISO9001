using ISO9001.Entities.Dtos;
using ISO9001.NonConformities.Repositories.Entities;
using ISO9001.NonConformities.Repositories.Interfaces;
using ISO9001.RegisterNonConformityDetail.BusinessObjects.Interfaces;

namespace ISO9001.NonConformities.Repositories
{
    internal class RegisterNonConformityDetailRepository(
        IRegisterNonCormityDetailDataContext dataContext): IRegisterNonConformityDetailRepository
    {
        public Task<bool> NonConformityExistsAsync(string companyId, string entityId)
        {
            NonConformityReadModel NonConformityMaster = dataContext.NonConformities
                .FirstOrDefault(nonConformity =>
                    nonConformity.CompanyId == companyId &&
                    nonConformity.EntityId == entityId);

            bool Exists = NonConformityMaster != null;
            return Task.FromResult(Exists);
        }

        public async Task RegisterNonConformityDetailAsync(NonConformityDto nonConformityDto)
        {

            NonConformityDetail NewDetail = new NonConformityDetail
            {
                ReportedBy = nonConformityDto.ReportedBy,
                Description = nonConformityDto.Description,
                Cause = nonConformityDto.Cause,
                Status = nonConformityDto.Status,
                ReportedAt = nonConformityDto.ReportedAt
            };

            await dataContext.AddAsync(NewDetail, nonConformityDto.CompanyId, nonConformityDto.EntityId);
        }

        public Task SaveChangesAsync() => dataContext.SaveChangesAsync();

    }
}
