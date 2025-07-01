using ISO9001.Entities.Dtos;

namespace ISO9001.RegisterNonConformityDetail.BusinessObjects.Interfaces
{
    public interface IRegisterNonConformityDetailRepository
    {
        Task RegisterNonConformityDetailAsync(NonConformityDto nonConformityDto);
        Task SaveChangesAsync();
        Task<bool> NonConformityExistsAsync(string companyId, string entityId);
    }
}
