using ISO9001.Entities.Dtos;

namespace ISO9001.RegisterNonConformity.BusinessObjects.Interfaces
{
    public interface IRegisterNonConformityInputPort
    {
        Task HandleAsync(NonConformityDto nonConformityDto);
    }
}
