using ISO9001.Entities.Responses;
using ISO9001.GetNonConformityByEntityId.BusinessObjects;
using ISO9001.NonConformities.Repositories.Interfaces;

namespace ISO9001.NonConformities.Repositories
{
    internal class GetNonConformityByEntityIdRepository(
        IQueryableNonConformityDataContext nonConformityDataContext) : IGetNonConformityByEntityIdRepository
    {
        public async Task<IEnumerable<NonConformityResponse>> GetNonConformityByEntityIdAsync(string id, string entityId, DateTime? from, DateTime? end)
        {
            var Query = nonConformityDataContext.NonConformities
                .Join(nonConformityDataContext.NonConformityDetails,
                    NonConformity => NonConformity.Id,
                    NonConformityDetail => NonConformityDetail.NonConformityId,
                    (NonConformity, NonConformityDetails) => new { NonConformity, NonConformityDetails })
                .Where(NonConformityResult =>
                    NonConformityResult.NonConformity.CompanyId == id &&
                    NonConformityResult.NonConformity.Id.ToString() == entityId)
                .GroupBy(NonConformity => NonConformity.NonConformity);

            return await nonConformityDataContext.ToListAsync(
                Query.Select(NonConformity => new NonConformityResponse(
                    NonConformity.Key.ReportedAt,
                    NonConformity.Key.AffectedProcess,
                    NonConformity.Key.Status,
                    NonConformity.Key.Cause,
                    nonConformityDataContext.NonConformityDetails.
                        Where(Detail =>
                        Detail.NonConformityId == NonConformity.Key.Id &&
                        Detail.ReportedAt >= from &&
                        Detail.ReportedAt <= end)
                        .Select(Detail => new NonConformityDetailResponse(
                            Detail.ReportedAt,
                            Detail.ReportedBy,
                            Detail.Description,
                            Detail.Status)
                        )
                        .OrderBy(Detail => Detail.ReportedAt).ToList())));
        }
    }
}
