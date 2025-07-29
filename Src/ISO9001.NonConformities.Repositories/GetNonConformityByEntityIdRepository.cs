using ISO9001.Entities.Responses;
using ISO9001.GetNonConformityByEntityId.BusinessObjects;
using ISO9001.NonConformities.Repositories.Interfaces;
using System.Linq;

namespace ISO9001.NonConformities.Repositories
{
    internal class GetNonConformityByEntityIdRepository(
        IQueryableNonConformityDataContext nonConformityDataContext) : IGetNonConformityByEntityIdRepository
    {
        public async Task<IEnumerable<NonConformityResponse>> GetNonConformityByEntityIdAsync(string id, string entityId, DateTime? from, DateTime? end)
        {
            var NonConformities = await nonConformityDataContext.ToListAsync(
                nonConformityDataContext.NonConformities
                    .Where(NonConformity => NonConformity.CompanyId == id && NonConformity.Id.ToString() == entityId)
            );

            var NonConformityDetails = await nonConformityDataContext.ToListAsync(
                nonConformityDataContext.NonConformityDetails
                    .Where(d =>
                        d.NonConformityId.ToString() == entityId &&
                        d.ReportedAt >= from &&
                        d.ReportedAt <= end)
                    );

            return NonConformities
                .Select(NonConformity => new NonConformityResponse(
                    NonConformity.ReportedAt,
                    NonConformity.AffectedProcess,
                    NonConformity.Status,
                    NonConformity.Cause,
                    NonConformityDetails
                        .Where(Detail => Detail.NonConformityId == NonConformity.Id)
                        .OrderBy(Detail => Detail.ReportedAt)
                        .Select(Detail => new NonConformityDetailResponse(
                            Detail.ReportedAt,
                            Detail.ReportedBy,
                            Detail.Description,
                            Detail.Status))
                        .ToList()
                ))
                .ToList();

        }
    }
}
