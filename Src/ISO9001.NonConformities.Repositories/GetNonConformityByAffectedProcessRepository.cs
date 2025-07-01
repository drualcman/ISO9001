using ISO9001.Entities.Responses;
using ISO9001.GetNonConformityByAffectedProcess.BusinessObjects;
using ISO9001.NonConformities.Repositories.Interfaces;

namespace ISO9001.NonConformities.Repositories
{
    internal class GetNonConformityByAffectedProcessRepository(
        IGetNonConformityByAffectedProcessDataContext dataContext) : IGetNonConformityByAffectedProcessRepository
    {
        public async Task<IEnumerable<NonConformityResponse>> GetNonConformityByAffectedProcesssAsync(string id, string affectedProcess, DateTime? from, DateTime? end)
        {
            var Query = dataContext.NonConformities
                .Where(NonConformity =>
                    NonConformity.CompanyId == id &&
                    NonConformity.AffectedProcess == affectedProcess &&
                    NonConformity.ReportedAt >= from &&
                    NonConformity.ReportedAt <= end);


            return await dataContext.ToListAsync(
                Query.Select(NonConformity => new NonConformityResponse(
                    NonConformity.EntityId,
                    NonConformity.ReportedAt,
                    NonConformity.AffectedProcess,
                    NonConformity.Status,
                    dataContext.NonConformityDetails
                    .Where(NonConformityDetails => NonConformityDetails.NonConformityId == NonConformity.Id)
                    .Select(NonConformityDetails => new NonConformityDetailResponse(
                        NonConformityDetails.ReportedAt,
                        NonConformityDetails.ReportedBy,
                        NonConformityDetails.Description,
                        NonConformityDetails.Cause,
                        NonConformityDetails.Status)).ToList())));
        }
    }
}
