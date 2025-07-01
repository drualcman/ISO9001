using ISO9001.Entities.Responses;
using ISO9001.GetNonConformityByEntityId.BusinessObjects;

namespace ISO9001.GetNonConformityByEntityId.Core.Handlers
{
    internal class GetNonConformityByEntityIdHandler(
        IGetNonConformityByEntityIdRepository repository) : IGetNonConformityByEntityIdInputPort
    {
        public async Task<IEnumerable<NonConformityResponse>> HandleAsync(string id, string entityId)
        {
            return await repository.GetNonConformityByEntityIdAsync(id, entityId);
        }
    }
}
