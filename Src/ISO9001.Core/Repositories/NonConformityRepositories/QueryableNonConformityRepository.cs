namespace ISO9001.Core.Repositories.NonConformityRepositories;

internal class QueryableNonConformityRepository(
    IQueryableNonConformityDataContext dataContext) : IQueryableNonConformityRepository
{
    public async Task<IEnumerable<NonConformityMaterResponse>> GetAllNonConformitiesAsync(string id, DateTime? from, DateTime? end)
    {
        var Query = dataContext.NonConformities
            .Where(NonConformity =>
                NonConformity.CompanyId == id &&
                NonConformity.ReportedAt >= from &&
                NonConformity.ReportedAt <= end)
            .OrderBy(NonConformity => NonConformity.ReportedAt);

        var NonConformities = await dataContext.ToListAsync(Query);

        return NonConformities.Select(
            NonConformity => new NonConformityMaterResponse(
                NonConformity.Id,
                NonConformity.EntityId,
                NonConformity.ReportedAt,
                NonConformity.AffectedProcess,
                NonConformity.Cause,
                NonConformity.Status,
                dataContext.NonConformityDetails.Count(NonConformityDetail =>
                    NonConformityDetail.NonConformityId == NonConformity.Id)));
    }

    public async Task<IEnumerable<NonConformityMaterResponse>> GetNonCormityMasterByEntityIdAsync(string id, string entityId, DateTime? from, DateTime? end)
    {
        var Query = dataContext.NonConformities
            .Where(NonConformity =>
                NonConformity.CompanyId == id &&
                NonConformity.EntityId == entityId &&
                NonConformity.ReportedAt >= from &&
                NonConformity.ReportedAt <= end)
            .OrderBy(NonConformity => NonConformity.ReportedAt);

        var NonConformities = await dataContext.ToListAsync(Query);

        return NonConformities.Select(
            NonConformity => new NonConformityMaterResponse(
                NonConformity.Id,
                NonConformity.EntityId,
                NonConformity.ReportedAt,
                NonConformity.AffectedProcess,
                NonConformity.Cause,
                NonConformity.Status,
                dataContext.NonConformityDetails.Count(NonConformityDetail =>
                    NonConformityDetail.NonConformityId == NonConformity.Id)));
    }

    public async Task<IEnumerable<NonConformityMaterResponse>> GetNonConformityByAffectedProcesssAsync(string id, string affectedProcess,
        DateTime? from, DateTime? end)
    {
        var Query = dataContext.NonConformities
            .Where(NonConformity =>
                NonConformity.CompanyId == id &&
                NonConformity.AffectedProcess == affectedProcess &&
                NonConformity.ReportedAt >= from &&
                NonConformity.ReportedAt <= end)
            .OrderBy(NonConformity => NonConformity.ReportedAt);

        var NonConformities = await dataContext.ToListAsync(Query);

        return NonConformities.Select(
            NonConformity => new NonConformityMaterResponse(
                NonConformity.Id,
                NonConformity.EntityId,
                NonConformity.ReportedAt,
                NonConformity.AffectedProcess,
                NonConformity.Cause,
                NonConformity.Status,
                dataContext.NonConformityDetails.Count(NonConformityDetail =>
                    NonConformityDetail.NonConformityId == NonConformity.Id)));
    }

    public async Task<NonConformityResponse> GetNonConformityByEntityIdAsync(string id, string entityId, DateTime? from, DateTime? end)
    {
        var NonConformity = dataContext.NonConformities
            .FirstOrDefault(NonConformity => NonConformity.CompanyId == id &&
                NonConformity.Id.ToString() == entityId &&
                NonConformity.ReportedAt >= from &&
                NonConformity.ReportedAt <= end);

        var NonConformityDetails = await dataContext.ToListAsync(
            dataContext.NonConformityDetails
                .Where(d =>
                    d.NonConformityId.ToString() == entityId &&
                    d.ReportedAt >= from &&
                    d.ReportedAt <= end)
                );

        return new NonConformityResponse(
            NonConformity.ReportedAt,
            NonConformity.AffectedProcess,
            NonConformity.Status,
            NonConformity.Cause,
            NonConformityDetails.Select(detail => new NonConformityDetailResponse(
                detail.ReportedAt,
                detail.ReportedBy,
                detail.Description,
                detail.Status
            )).ToList()
        );

    }

    public async Task<IEnumerable<NonConformityMaterResponse>> GetNonConformityByStatusAsync(string id, string status, DateTime? from, DateTime? end)
    {
        var Query = dataContext.NonConformities
            .Where(NonConformity =>
                NonConformity.CompanyId == id &&
                NonConformity.Status == status &&
                NonConformity.ReportedAt >= from &&
                NonConformity.ReportedAt <= end)
            .OrderBy(NonConformity => NonConformity.ReportedAt);

        var NonConformities = await dataContext.ToListAsync(Query);

        return NonConformities.Select(
            NonConformity => new NonConformityMaterResponse(
                NonConformity.Id,
                NonConformity.EntityId,
                NonConformity.ReportedAt,
                NonConformity.AffectedProcess,
                NonConformity.Cause,
                NonConformity.Status,
                dataContext.NonConformityDetails.Count(NonConformityDetail =>
                    NonConformityDetail.NonConformityId == NonConformity.Id)));
    }

    public Task<bool> NonConformityExistsByGuidAsync(Guid entityId)
    {
        NonConformityReadModel NonConformityMaster = dataContext.NonConformities
            .FirstOrDefault(nonConformity =>
                nonConformity.Id == entityId);

        bool Exists = NonConformityMaster != null;
        return Task.FromResult(Exists);
    }
}
