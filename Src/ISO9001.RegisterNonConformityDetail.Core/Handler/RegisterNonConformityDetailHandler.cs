using ISO9001.Entities.Dtos;
using ISO9001.RegisterNonConformityDetail.BusinessObjects.Interfaces;

namespace ISO9001.RegisterNonConformityDetail.Core.Handler
{
    internal class RegisterNonConformityDetailHandler
        (IRegisterNonConformityDetailRepository repository) : IRegisterNonConformityDetailInputPort
    {
        public async Task HandleAsync(NonConformityDto nonConformityDto)
        {
            bool NonConformityExists = await repository.NonConformityExistsAsync(nonConformityDto.CompanyId, nonConformityDto.EntityId);
            if (!NonConformityExists)
            {
                throw new InvalidOperationException("NonConformity doesn't exist");
            }
            else
            {
                await repository.RegisterNonConformityDetailAsync(nonConformityDto);
                await repository.SaveChangesAsync();
            }

        }
    }
}
