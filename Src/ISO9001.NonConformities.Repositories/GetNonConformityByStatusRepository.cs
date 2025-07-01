using ISO9001.Entities.Responses;
using ISO9001.GetNonConformityByStatus.BusinessObjects;
using ISO9001.NonConformities.Repositories.Interfaces;

namespace ISO9001.NonConformities.Repositories
{
    internal class GetNonConformityByStatusRepository
        (IGetNonConformityByStatusDataContext dataContext) : IGetNonConformityByStatusRepository
    {
        public async Task<IEnumerable<NonConformityResponse>> GetNonConformityByStatusAsync(string id, string status, DateTime? from, DateTime? end)
        {
            var Query = dataContext.NonConformities
                .Where(NonConformity =>
                    NonConformity.CompanyId == id &&
                    NonConformity.Status == status &&
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
