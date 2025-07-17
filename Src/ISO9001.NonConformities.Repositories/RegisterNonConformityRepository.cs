using ISO9001.Entities.Dtos;
using ISO9001.NonConformities.Repositories.Entities;
using ISO9001.NonConformities.Repositories.Interfaces;
using ISO9001.RegisterNonConformity.BusinessObjects.Interfaces;

namespace ISO9001.NonConformities.Repositories
{
    internal class RegisterNonConformityRepository(
        IWritableNonConformityDataContext writableNonConformityDataContext) : IRegisterNonConformityRepository
    {
        async Task IRegisterNonConformityRepository.RegisterNonConformityAsync(NonConformityDto nonConformityDto)
        {
            NonConformity NewNonConformityMaster = new NonConformity
            {
                Id = Guid.NewGuid(),
                ReportedAt = nonConformityDto.ReportedAt,
                CompanyId = nonConformityDto.CompanyId,
                EntityId = nonConformityDto.EntityId,
                AffectedProcess = nonConformityDto.AffectedProcess,
                Cause = nonConformityDto.Cause,
                Status = nonConformityDto.Status,
                NonConformityDetails = new List<NonConformityDetail>()
            };

            NonConformityDetail NewNonConformityDetail = new NonConformityDetail
            {
                ReportedAt = nonConformityDto.ReportedAt,
                ReportedBy = nonConformityDto.ReportedBy,
                Description = nonConformityDto.Description,
                Status = nonConformityDto.Status
            };

            NewNonConformityMaster.NonConformityDetails.Add(NewNonConformityDetail);
            await writableNonConformityDataContext.AddNonConformityAsync(NewNonConformityMaster);
            await writableNonConformityDataContext.AddNonConformityDetailAsync(NewNonConformityDetail, NewNonConformityMaster.Id);
        }

        async Task IRegisterNonConformityRepository.SaveChangesAsync()
        {
            await writableNonConformityDataContext.SaveChangesAsync();
        }

    }
}
