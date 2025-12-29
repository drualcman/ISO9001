namespace ISO9001.Core.Responses;
public class NonConformityMaterResponse(string id, string entityId, DateTime reportedAt,
    string affectedProcess, string cause, string status, int detailsCount)
{
    public string Id => id;
    public string EntityId => entityId;
    public DateTime ReportedAt => reportedAt;
    public string AffectedProcess => affectedProcess;
    public string Cause => cause;
    public string Status => status;
    public int DetailsCount => detailsCount;
}
