using ISO9001.Core.Dtos;

namespace ISO9001.Core.Features.Interfaces;

public interface ICommandNonConformityDetailRepository
{
    Task RegisterNonConformityDetailAsync(NonConformityCreateDetailDto nonConformityDetail);
    Task SaveChangesAsync();
}
