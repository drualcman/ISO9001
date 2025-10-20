namespace ISO9001.Repositories.NonConformityRepositories.AuditEventProvider
{
    internal class NonConformityEventProvider(IQueryableNonConformityDataContext context) : IAuditEventProvider
    {
        public string EventType => "NonConformity";

        public async Task<IEnumerable<AuditEventResponse>> GetAuditEventsAsync(string entityId, string companyId)
        {
            var Query = context.NonConformities
                .Where(NonConformity => NonConformity.EntityId == entityId && NonConformity.CompanyId == companyId)
                .OrderBy(NonConformity => NonConformity.ReportedAt);

            var NonConformities = await context.ToListAsync(Query);

            var Result = NonConformities.Select(NonConformity =>
            {
                var LastDetail = context.NonConformityDetails
                .Where(Detail => Detail.NonConformityId == NonConformity.Id)
                .OrderByDescending(Detail => Detail.CreatedAt)
                .FirstOrDefault();

                return new AuditEventResponse(
                    NonConformity.Id.ToString(),
                    NonConformity.EntityId,
                    NonConformity.ReportedAt,
                    EventType,
                    LastDetail.Description,
                    LastDetail.ReportedBy
                    );
            });

            return await Task.FromResult(Result);
        }
    }
}
