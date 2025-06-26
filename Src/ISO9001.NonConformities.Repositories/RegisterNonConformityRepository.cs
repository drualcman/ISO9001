using ISO9001.Entities.Dtos;
using ISO9001.NonConformities.Repositories.Entities;
using ISO9001.NonConformities.Repositories.Interfaces;
using ISO9001.RegisterNonConformity.BusinessObjects.Interfaces;

namespace ISO9001.NonConformities.Repositories
{
    internal class RegisterNonConformityRepository(
        IRegisterNonConformityDataContext dataContext) : IRegisterNonConformityRepository
    {
        async Task IRegisterNonConformityRepository.RegisterNonConformityAsync(NonConformityDto nonConformityDto)
        {
            NonConformity NewNonConformityMaster = new NonConformity
            {
                ReportedAt = nonConformityDto.ReportedAt,
                CompanyId = nonConformityDto.CompanyId,
                EntityId = nonConformityDto.EntityId,
                AffectedProcess = nonConformityDto.AffectedProcess,
                Status = nonConformityDto.Status,
                NonConformityDetails = new List<NonConformityDetail>()
            };

            NonConformityDetail NewNonConformityDetail = new NonConformityDetail
            {
                ReportedAt = nonConformityDto.ReportedAt,
                ReportedBy = nonConformityDto.ReportedBy,
                Description = nonConformityDto.Description,
                Cause = nonConformityDto.Cause,
                Status = nonConformityDto.Status
            };

            NewNonConformityMaster.NonConformityDetails.Add(NewNonConformityDetail);

            await dataContext.AddAsync(NewNonConformityMaster);
        }

        Task IRegisterNonConformityRepository.SaveChangesAsync() => dataContext.SaveChangesAsync();

    }
}
