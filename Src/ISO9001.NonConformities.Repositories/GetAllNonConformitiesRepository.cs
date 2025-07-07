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
        public async Task<IEnumerable<NonConformityMaterResponse>> GetAllNonConformitiesAsync(string id, DateTime? from, DateTime? end)
        {
            var Query = dataContext.NonConformities
                .Where(NonConformity =>
                    NonConformity.CompanyId == id &&
                    NonConformity.ReportedAt >= from &&
                    NonConformity.ReportedAt <= end)
                .OrderBy(NonConformity => NonConformity.ReportedAt);


            return await dataContext.ToListAsync(
                Query.Select(NonConformity => new NonConformityMaterResponse(
                    NonConformity.Id,
                    NonConformity.EntityId,
                    NonConformity.ReportedAt,
                    NonConformity.AffectedProcess,
                    NonConformity.Cause,
                    NonConformity.Status,
                    dataContext.NonConformityDetails.Count(NonConformityDetail => 
                    NonConformityDetail.NonConformityId == NonConformity.Id)
                    )));

        }
    }
}
