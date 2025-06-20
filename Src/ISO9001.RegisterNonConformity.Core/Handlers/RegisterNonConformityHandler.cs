using ISO9001.Entities.Dtos;
using ISO9001.RegisterNonConformity.BusinessObjects.Interfaces;

namespace ISO9001.RegisterNonConformity.Core.Handlers
{
    internal class RegisterNonConformityHandler
        (IRegisterNonConformityRepository repository) : IRegisterNonConformityInputPort
    {
        public async Task HandleAsync(NonConformityDto nonConformityDto)
        {
            await repository.RegisterNonConformityAsync(nonConformityDto);
            await repository.SaveChangesAsync();
        }
    }
}
