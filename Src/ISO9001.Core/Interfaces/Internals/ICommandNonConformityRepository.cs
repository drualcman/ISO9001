namespace ISO9001.Core.Interfaces.Internals;

internal interface ICommandNonConformityRepository
{
    Task RegisterNonConformityAsync(NonConformityDto nonConformityDto);
    Task UpdateStatusNonConformityMasterAsync(Guid entityId, string status);
    Task SaveChangesAsync();
}
