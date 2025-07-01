using ISO9001.Entities.Responses;
using ISO9001.GetNonConformityByEntityId.BusinessObjects;
using ISO9001.NonConformities.Repositories.Interfaces;

namespace ISO9001.NonConformities.Repositories
{
    internal class GetNonConformityByEntityIdRepository
        (IGetNonConformityByEntityIdDataContext dataContext) : IGetNonConformityByEntityIdRepository
    {
        public async Task<IEnumerable<NonConformityResponse>> GetNonConformityByEntityIdAsync(string id, string entityId)
        {
            var Query = dataContext.NonConformities
                .Where(NonConformity =>
                    NonConformity.CompanyId == id &&
                    NonConformity.EntityId == entityId);


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
