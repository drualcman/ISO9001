using ISO9001.Core.Dtos;

namespace ISO9001.Core.Features.Interfaces;

public interface ICommandNonConformityRepository
{
    Task RegisterNonConformityAsync(NonConformityDto nonConformityDto);
    Task UpdateStatusNonConformityMasterAsync(Guid entityId, string status);
    Task SaveChangesAsync();
}
