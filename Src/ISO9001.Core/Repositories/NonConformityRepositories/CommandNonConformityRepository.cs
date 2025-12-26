namespace ISO9001.Core.Repositories.NonConformityRepositories;

internal class CommandNonConformityRepository(
    IWritableNonConformityDataContext commandDataContext,
    IQueryableNonConformityDataContext queryDataContext) : ICommandNonConformityRepository
{
    public async Task RegisterNonConformityAsync(NonConformityDto nonConformityDto)
    {
        NonConformity NewNonConformityMaster = new NonConformity
        {
            Id = Guid.NewGuid(),
            ReportedAt = nonConformityDto.ReportedAt,
            CompanyId = nonConformityDto.CompanyId,
            EntityId = nonConformityDto.EntityId,
            AffectedProcess = nonConformityDto.AffectedProcess,
            Cause = nonConformityDto.Cause,
            Status = nonConformityDto.Status.ToLower(),
            NonConformityDetails = new List<NonConformityDetail>()
        };

        NonConformityDetail NewNonConformityDetail = new NonConformityDetail
        {
            ReportedAt = nonConformityDto.ReportedAt,
            ReportedBy = nonConformityDto.ReportedBy,
            Description = nonConformityDto.Description,
            Status = nonConformityDto.Status.ToLower()
        };

        NewNonConformityMaster.NonConformityDetails.Add(NewNonConformityDetail);
        await commandDataContext.AddNonConformityAsync(NewNonConformityMaster);
        await commandDataContext.AddNonConformityDetailAsync(NewNonConformityDetail, NewNonConformityMaster.Id);
    }

    public async Task SaveChangesAsync() => await commandDataContext.SaveChangesAsync();

    public Task UpdateStatusNonConformityMasterAsync(Guid entityId, string status)
    {
        NonConformityReadModel NonConformityMaster = queryDataContext.NonConformities
            .FirstOrDefault(nonConformity =>
                nonConformity.Id == entityId);

        NonConformityMaster.Status = status.ToLower();
        commandDataContext.UpdateNonConformityAsync(NonConformityMaster);
        return Task.CompletedTask;
    }
}
