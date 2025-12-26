namespace ISO9001.Core.Responses;

public class NonConformityResponse(DateTime repotedAt, string affectedProcess,
    string status, string cause, List<NonConformityDetailResponse> details)
{
    public DateTime ReportedAt => repotedAt;
    public string AffectedProcess => affectedProcess;
    public string Status => status;
    public string Cause => cause;
    public List<NonConformityDetailResponse> Details => details;

}
