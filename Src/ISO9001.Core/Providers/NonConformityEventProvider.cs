namespace ISO9001.Core.Providers;

internal class NonConformityEventProvider(IQueryableNonConformityDataContext context) : IAuditEventProvider
{
    public string EventType => "NonConformity";

    public async Task<IEnumerable<AuditEventResponse>> GetAuditEventsAsync(string entityId, string companyId)
    {
        var NonConformities = await context.ToListAsync(
            NonConformity =>
                NonConformity.EntityId == entityId &&
                NonConformity.CompanyId == companyId,
            NonConformity => NonConformity.OrderBy(nc => nc.ReportedAt)
        );

        var NonConformityIds = NonConformities
            .Select(NC => NC.Id)
            .ToList();

        var Details = await context.ToListAsync(
            Detail => NonConformityIds.Contains(Detail.NonConformityId),
            Detail => Detail.OrderByDescending(d => d.CreatedAt)
        );

        var LastDetails = Details
            .GroupBy(d => d.NonConformityId)
            .ToDictionary(
                g => g.Key,
                g => g.First()
            );


        var Result = NonConformities.Select(NC =>
        {
            LastDetails.TryGetValue(NC.Id, out var LastDetail);

            return new AuditEventResponse(
                NC.Id.ToString(),
                NC.EntityId,
                NC.ReportedAt,
                EventType,
                LastDetail?.Description,
                LastDetail?.ReportedBy
            );
        });

        return Result;
    }
}
