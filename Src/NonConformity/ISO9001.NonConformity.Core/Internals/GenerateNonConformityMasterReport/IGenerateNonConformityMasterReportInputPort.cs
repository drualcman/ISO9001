namespace ISO9001.NonConformity.Core.Internals.GenerateNonConformityMasterReport
{
    public interface IGenerateNonConformityMasterReportInputPort
    {
        ValueTask GenerateNonConformityMasterReportAsync(string companyId, string entityId, DateTime? from, DateTime? end);
    }
}
