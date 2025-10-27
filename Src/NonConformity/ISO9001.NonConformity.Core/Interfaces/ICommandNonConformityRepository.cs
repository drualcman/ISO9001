namespace ISO9001.NonConformity.Core.Interfaces
{
    public interface ICommandNonConformityRepository
    {
        Task RegisterNonConformityAsync(NonConformityDto nonConformityDto);
        Task UpdateStatusNonConformityMasterAsync(Guid entityId, string status);
        Task SaveChangesAsync();
    }
}
