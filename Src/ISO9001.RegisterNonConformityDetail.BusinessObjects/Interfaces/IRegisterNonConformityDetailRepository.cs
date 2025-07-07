using ISO9001.Entities.Dtos;

namespace ISO9001.RegisterNonConformityDetail.BusinessObjects.Interfaces
{
    public interface IRegisterNonConformityDetailRepository
    {
        Task RegisterNonConformityDetailAsync(NonConformityCreateDetailDto nonConformityDetail);
        Task SaveChangesAsync();
        Task UpdateStatusNonConformityMasterAsync(Guid entityId, string status);
        Task<bool> NonConformityExistsByGuidAsync(Guid entityId);
    }
}
