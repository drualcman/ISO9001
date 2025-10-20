namespace ISO9001.NonConformity.Core.Interfaces
{
    public interface ICommandNonConformityDetailRepository
    {
        Task RegisterNonConformityDetailAsync(NonConformityCreateDetailDto nonConformityDetail);
        Task SaveChangesAsync();
    }
}
