using ISO9001.Entities.Responses;
using ISO9001.GetAllNonConformities.BusinessObjects;
using ISO9001.NonConformities.Repositories.Interfaces;

namespace ISO9001.NonConformities.Repositories
{
    internal class GetAllNonConformitiesRepository
        (IGetAllNonConformitiesDataContext dataContext) : IGetAllNonConformitiesRepository
    {
        public async Task<IEnumerable<NonConformityResponse>> GetAllNonConformitiesAsync(string id, DateTime? from, DateTime? end)
        {
            var Query = dataContext.NonConformities
                .Join(dataContext.NonConformityDetails,
                    NonConformity => NonConformity.Id,
                    NonConformityDetail => NonConformityDetail.NonConformityId,
                    (NonConformity, NonConformityDetail) => new { NonConformity, NonConformityDetail })
                .Where(NonConformityResult =>
                    NonConformityResult.NonConformity.CompanyId == id &&
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
