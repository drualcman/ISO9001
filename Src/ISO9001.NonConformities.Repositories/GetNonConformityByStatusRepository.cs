using ISO9001.Entities.Responses;
using ISO9001.GetNonConformityByStatus.BusinessObjects;
using ISO9001.NonConformities.Repositories.Interfaces;

namespace ISO9001.NonConformities.Repositories
{
    internal class GetNonConformityByStatusRepository(
        IQueryableNonConformityDataContext nonConformityDataContext) : IGetNonConformityByStatusRepository
    {
        public async Task<IEnumerable<NonConformityMaterResponse>> GetNonConformityByStatusAsync(string id, string status, DateTime? from, DateTime? end)
        {
            var Query = nonConformityDataContext.NonConformities
                .Where(NonConformity =>
                    NonConformity.CompanyId == id &&
                    NonConformity.Status == status &&
                    NonConformity.ReportedAt >= from &&
                    NonConformity.ReportedAt <= end)
                .OrderBy(NonConformity => NonConformity.ReportedAt);

            return await nonConformityDataContext.ToListAsync(
                Query.Select(NonConformity => new NonConformityMaterResponse(
                    NonConformity.Id,
                    NonConformity.EntityId,
                    NonConformity.ReportedAt,
                    NonConformity.AffectedProcess,
                    NonConformity.Cause,
                    NonConformity.Status,
                    nonConformityDataContext.NonConformityDetails.Count(NonConformityDetail => NonConformityDetail.NonConformityId == NonConformity.Id)
                    )));
        }
    }
}
