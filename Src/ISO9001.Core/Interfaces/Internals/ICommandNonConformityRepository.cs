namespace ISO9001.Core.Interfaces.Internals;

internal interface ICommandNonConformityRepository
{
    Task RegisterNonConformityAsync(NonConformityDto nonConformityDto);
    Task UpdateStatusNonConformityMasterAsync(string entityId, string status);
    Task SaveChangesAsync();
}
