using ISO9001.Entities.Responses;
using ISO9001.GetAllNonConformities.BusinessObjects;
using ISO9001.NonConformities.Repositories.Entities;
using ISO9001.NonConformities.Repositories.Interfaces;
using System.Linq;

namespace ISO9001.NonConformities.Repositories
{
    internal class GetAllNonConformitiesRepository
        (IGetAllNonConformitiesDataContext dataContext) : IGetAllNonConformitiesRepository
    {
        public async Task<IEnumerable<NonConformityResponse>> GetAllNonConformitiesAsync(string id, DateTime? from, DateTime? end)
        {
            var Query = dataContext.NonConformities
                .Where(NonConformity =>
                    NonConformity.CompanyId == id &&
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
