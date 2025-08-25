using ISO9001.Entities.Responses;
using ISO9001.GetAllNonConformities.BusinessObjects;
using ISO9001.Repositories.NonConformityRepositories.Interfaces;

namespace ISO9001.Repositories.NonConformityRepositories
{
    internal class GetAllNonConformitiesRepository(
        IQueryableNonConformityDataContext nonConformityDataContext) : IGetAllNonConformitiesRepository
    {
        public async Task<IEnumerable<NonConformityMaterResponse>> GetAllNonConformitiesAsync(string id, DateTime? from, DateTime? end)
        {
            var Query = nonConformityDataContext.NonConformities
                .Where(NonConformity =>
                    NonConformity.CompanyId == id &&
                    NonConformity.ReportedAt >= from &&
                    NonConformity.ReportedAt <= end)
                .OrderBy(NonConformity => NonConformity.ReportedAt);

            var NonConformities = await nonConformityDataContext.ToListAsync(Query);

            return NonConformities.Select(
                NonConformity => new NonConformityMaterResponse(
                    NonConformity.Id,
                    NonConformity.EntityId,
                    NonConformity.ReportedAt,
                    NonConformity.AffectedProcess,
                    NonConformity.Cause,
                    NonConformity.Status,
                    nonConformityDataContext.NonConformityDetails.Count(NonConformityDetail =>
                        NonConformityDetail.NonConformityId == NonConformity.Id)));
        }
    }
}
