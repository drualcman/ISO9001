using ISO9001.Entities.Responses;
using ISO9001.GetNonConformityByAffectedProcess.BusinessObjects;
using ISO9001.Repositories.NonConformityRepositories.Interfaces;

namespace ISO9001.Repositories.NonConformityRepositories
{
    internal class GetNonConformityByAffectedProcessRepository(IQueryableNonConformityDataContext nonConformityDataContext) : IGetNonConformityByAffectedProcessRepository
    {
        public async Task<IEnumerable<NonConformityMaterResponse>> GetNonConformityByAffectedProcesssAsync(string id, string affectedProcess, 
            DateTime? from, DateTime? end)
        {
            var Query = nonConformityDataContext.NonConformities
                .Where(NonConformity =>
                    NonConformity.CompanyId == id &&
                    NonConformity.AffectedProcess == affectedProcess &&
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
