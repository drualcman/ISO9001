namespace ISO9001.Core.Repositories.NonConformityRepositories;

internal class CommandNonConformityDetailRepository(
    IWritableNonConformityDataContext dataContext) : ICommandNonConformityDetailRepository
{

    public async Task RegisterNonConformityDetailAsync(NonConformityCreateDetailDto nonConformityDetail)
    {

        NonConformityDetail NewDetail = new NonConformityDetail
        {
            ReportedBy = nonConformityDetail.ReportedBy,
            Description = nonConformityDetail.Description,
            Status = nonConformityDetail.Status.ToLower(),
            ReportedAt = nonConformityDetail.ReportedAt
        };

        await dataContext.AddNonConformityDetailAsync(NewDetail, nonConformityDetail.EntityId);
    }
    public async Task SaveChangesAsync() => await dataContext.SaveChangesAsync();
}
