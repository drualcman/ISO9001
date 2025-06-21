using ISO9001.Entities.Dtos;

namespace ISO9001.RegisterNonConformity.BusinessObjects.Interfaces
{
    public interface IRegisterNonConformityRepository
    {
        Task RegisterNonConformityAsync(NonConformityDto nonConformityDto);
        Task SaveChangesAsync();
    }
}
