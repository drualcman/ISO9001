namespace ISO9001.Core.Interfaces.Internals;

internal interface IQueryableNonConformityRepository
{
    Task<IEnumerable<NonConformityMaterResponse>> GetAllNonConformitiesAsync(string id, DateTime? from, DateTime? end);
    Task<IEnumerable<NonConformityMaterResponse>> GetNonCormityMasterByEntityIdAsync(string id, string entityId, DateTime? from, DateTime? end);
    Task<IEnumerable<NonConformityMaterResponse>> GetNonConformityByAffectedProcesssAsync(string id, string affectedProcess, DateTime? from, DateTime? end);
    Task<NonConformityResponse> GetNonConformityByEntityIdAsync(string id, string entityId, DateTime? from, DateTime? end);
    Task<IEnumerable<NonConformityMaterResponse>> GetNonConformityByStatusAsync(string id, string status, DateTime? from, DateTime? end);
    Task<bool> NonConformityExistsByGuidAsync(string entityId);
}
