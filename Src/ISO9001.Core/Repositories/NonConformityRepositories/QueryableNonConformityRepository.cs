namespace ISO9001.Core.Repositories.NonConformityRepositories;

internal class QueryableNonConformityRepository(
    IQueryableNonConformityDataContext dataContext) : IQueryableNonConformityRepository
{
    public async Task<IEnumerable<NonConformityMaterResponse>> GetAllNonConformitiesAsync(string id, DateTime? from, DateTime? end)
    {
        var NonConformities = await dataContext.ToListAsync(
            NonConformity =>
                NonConformity.CompanyId == id &&
                NonConformity.ReportedAt >= from &&
                NonConformity.ReportedAt <= end,
            NonConformity => NonConformity.OrderBy(nc => nc.ReportedAt)
        );

        var NonConformityIds = NonConformities
            .Select(NC => NC.Id)
            .ToList();

        var Details = await dataContext.ToListAsync(details =>
        NonConformityIds.Contains(details.NonConformityId));

        var DetailsCount = Details
            .GroupBy(d => d.NonConformityId)
            .ToDictionary(g => g.Key, g => g.Count());

        return NonConformities.Select(NC =>
            new NonConformityMaterResponse(
                NC.Id,
                NC.EntityId,
                NC.ReportedAt,
                NC.AffectedProcess,
                NC.Cause,
                NC.Status,
                DetailsCount.TryGetValue(NC.Id, out var count) ? count : 0
            ));
    }

    public async Task<IEnumerable<NonConformityMaterResponse>> GetNonCormityMasterByEntityIdAsync(string id, string entityId, DateTime? from, DateTime? end)
    {
        var NonConformities = await dataContext.ToListAsync(
            NonConformity =>
                NonConformity.CompanyId == id &&
                NonConformity.EntityId == entityId &&
                NonConformity.ReportedAt >= from &&
                NonConformity.ReportedAt <= end,
            NonConformity => NonConformity.OrderBy(nc => nc.ReportedAt)
        );

        var NonConformityIds = NonConformities
            .Select(NC => NC.Id)
            .ToList();

        var Details = await dataContext.ToListAsync(
            detail => NonConformityIds.Contains(detail.NonConformityId)
        );

        var DetailsCount = Details
            .GroupBy(d => d.NonConformityId)
            .ToDictionary(g => g.Key, g => g.Count());

        return NonConformities.Select(NC =>
            new NonConformityMaterResponse(
                NC.Id,
                NC.EntityId,
                NC.ReportedAt,
                NC.AffectedProcess,
                NC.Cause,
                NC.Status,
                DetailsCount.TryGetValue(NC.Id, out var count) ? count : 0
            ));
    }

    public async Task<IEnumerable<NonConformityMaterResponse>> GetNonConformityByAffectedProcesssAsync(string id, string affectedProcess,
        DateTime? from, DateTime? end)
    {
        var NonConformities = await dataContext.ToListAsync(
            NonConformity =>
                NonConformity.CompanyId == id &&
                NonConformity.AffectedProcess == affectedProcess &&
                NonConformity.ReportedAt >= from &&
                NonConformity.ReportedAt <= end,
            NonConformity => NonConformity.OrderBy(nc => nc.ReportedAt)
        );

        var NonConformityIds = NonConformities
            .Select(NC => NC.Id)
            .ToList();

        var Details = await dataContext.ToListAsync(
            detail => NonConformityIds.Contains(detail.NonConformityId)
        );

        var DetailsCount = Details
            .GroupBy(d => d.NonConformityId)
            .ToDictionary(g => g.Key, g => g.Count());

        return NonConformities.Select(NC =>
            new NonConformityMaterResponse(
                NC.Id,
                NC.EntityId,
                NC.ReportedAt,
                NC.AffectedProcess,
                NC.Cause,
                NC.Status,
                DetailsCount.TryGetValue(NC.Id, out var count) ? count : 0
            ));
    }

    public async Task<NonConformityResponse> GetNonConformityByEntityIdAsync(string id, string entityId, DateTime? from, DateTime? end)
    {
        var NonConformity = (await dataContext.ToListAsync(
            nc =>
                nc.CompanyId == id &&
                nc.Id.ToString() == entityId &&
                nc.ReportedAt >= from &&
                nc.ReportedAt <= end
        )).FirstOrDefault();

        if (NonConformity == null)
            return null;

        var Details = await dataContext.ToListAsync(
            d =>
                d.NonConformityId.ToString() == entityId &&
                d.ReportedAt >= from &&
                d.ReportedAt <= end,
            d => d.OrderBy(x => x.ReportedAt)
        );

        return new NonConformityResponse(
            NonConformity.ReportedAt,
            NonConformity.AffectedProcess,
            NonConformity.Status,
            NonConformity.Cause,
            Details.Select(detail => new NonConformityDetailResponse(
                detail.ReportedAt,
                detail.ReportedBy,
                detail.Description,
                detail.Status
            )).ToList()
        );
    }

    public async Task<IEnumerable<NonConformityMaterResponse>> GetNonConformityByStatusAsync(string id, string status, DateTime? from, DateTime? end)
    {
        var NonConformities = await dataContext.ToListAsync(
            NonConformity =>
                NonConformity.CompanyId == id &&
                NonConformity.Status == status &&
                NonConformity.ReportedAt >= from &&
                NonConformity.ReportedAt <= end,
            NonConformity => NonConformity.OrderBy(nc => nc.ReportedAt)
        );

        var NonConformityIds = NonConformities
            .Select(NC => NC.Id)
            .ToList();

        var Details = await dataContext.ToListAsync(
            detail => NonConformityIds.Contains(detail.NonConformityId)
        );

        var DetailsCount = Details
            .GroupBy(d => d.NonConformityId)
            .ToDictionary(g => g.Key, g => g.Count());

        return NonConformities.Select(NC =>
            new NonConformityMaterResponse(
                NC.Id,
                NC.EntityId,
                NC.ReportedAt,
                NC.AffectedProcess,
                NC.Cause,
                NC.Status,
                DetailsCount.TryGetValue(NC.Id, out var count) ? count : 0
            ));
    }

    public async Task<bool> NonConformityExistsByGuidAsync(Guid entityId)
    {
        var NonConformity = await dataContext.ToListAsync(
            NC => NC.Id == entityId
        );

        return NonConformity.Any();
    }
}
