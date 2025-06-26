using ISO9001.Entities.Responses;
using ISO9001.GetNonConformityByEntityId.BusinessObjects;
using ISO9001.NonConformities.Repositories.Interfaces;

namespace ISO9001.NonConformities.Repositories
{
    internal class GetNonConformityByEntityIdRepository
        (IGetNonConformityByEntityIdDataContext dataContext) : IGetNonConformityByEntityIdRepository
    {
        public async Task<IEnumerable<NonConformityResponse>> GetNonConformityByEntityIdAsync(string id, string entityId, DateTime? from, DateTime? end)
        {
            var Query = dataContext.NonConformities
                .Join(dataContext.NonConformityDetails,
                    NonConformity => NonConformity.Id,
                    NonConformityDetail => NonConformityDetail.NonConformityId,
                    (NonConformity, NonConformityDetail) => new { NonConformity, NonConformityDetail })
                .Where(NonConformityResult =>
                    NonConformityResult.NonConformity.CompanyId == id &&
                    NonConformityResult.NonConformity.EntityId == entityId &&
                    NonConformityResult.NonConformity.ReportedAt >= from &&
                    NonConformityResult.NonConformity.ReportedAt <= end);

            return await dataContext.ToListAsync(
                Query.Select(NonConformityResult => new NonConformityResponse(
                    NonConformityResult.NonConformity.EntityId,
                    NonConformityResult.NonConformity.ReportedAt,
                    NonConformityResult.NonConformityDetail.ReportedBy,
                    NonConformityResult.NonConformityDetail.Description,
                    NonConformityResult.NonConformity.AffectedProcess,
                    NonConformityResult.NonConformityDetail.Cause,
                    NonConformityResult.NonConformity.Status)));
        }
    }
}
