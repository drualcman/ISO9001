namespace ISO9001.Core.Interfaces.Internals;

internal interface ICommandNonConformityDetailRepository
{
    Task RegisterNonConformityDetailAsync(NonConformityCreateDetailDto nonConformityDetail);
    Task SaveChangesAsync();
}
